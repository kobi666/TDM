using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineV2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string, StateV2> states;

    

    public bool StopDoingThingsWhileTransitioningToNewState = false;
    public class StateV2{

        public string _name = "EMPTY STATE";

        public virtual void OngoingFunctions() { Debug.Log("EMPTY ONGOING Function called");}

        public virtual IEnumerator OnStateEnterFunctions() {Debug.Log("EMPTY ENTER state routine called") ;  yield return null;}

        public virtual IEnumerator OnStateExitFunctions() {Debug.Log("EMPTY EXIT state routine called") ; yield return null;}
    }


    

    



    public StateV2 NewState = new StateV2();
    public StateV2 OldState = new StateV2();
    public StateV2 _currentState = new StateV2();

    public delegate void DelegateCurrentBehavior();
    DelegateCurrentBehavior _delegateCurrentBehavior;

    public delegate IEnumerator DoStuffWhenEnteringToNewState();
    public delegate IEnumerator DoStuffWhenExitingFromOldState();
    public delegate void DoStuffForTheCurrentState();

    DoStuffForTheCurrentState _doStuffForCurrentState;
    DoStuffWhenEnteringToNewState _doStuffWhenEnteringToNewState;
    DoStuffWhenExitingFromOldState _doStuffWhenExitingFromOldState;

    public IEnumerator StartExitFromOldStateSequence() {
        yield return StartCoroutine(_doStuffWhenExitingFromOldState());
    }

    public IEnumerator StartEnteringToNewStateSequence() {
        yield return StartCoroutine(_doStuffWhenEnteringToNewState());
    }

    
    IEnumerator StartChnagingStatesSequence() {
                
                //_doStuffWhenExitingFromOldState = OldState.OnStateExitFunctions;
                //Debug.Log("I reached here");
                yield return StartCoroutine(StartExitFromOldStateSequence());
                //_doStuffWhenEnteringToNewState = NewState.OnStateEnterFunctions;
                StopCoroutine(StartExitFromOldStateSequence());
                //Debug.Log("I reached HEER");
                yield return StartCoroutine(StartEnteringToNewStateSequence());
                StopCoroutine(StartEnteringToNewStateSequence());
                StopDoingThingsWhileTransitioningToNewState = false;
                
            }







    public void StateFunctionsExecutor() {
        
        if (StopDoingThingsWhileTransitioningToNewState == false) {
            _doStuffForCurrentState();
        }
        
    }

    public void StateChanger(StateV2 state) {
        if (state != null) {
        StopDoingThingsWhileTransitioningToNewState = true;
        OldState = _currentState;
        _currentState = state;
        _doStuffWhenExitingFromOldState = OldState.OnStateExitFunctions;
        _doStuffWhenEnteringToNewState = _currentState.OnStateEnterFunctions;
        _doStuffForCurrentState = _currentState.OngoingFunctions;
        StartCoroutine(StartChnagingStatesSequence());
        }
    }

    public void SequenceStarter() {
        //Debug.Log("Started changing states sequence");
        StartCoroutine(StartChnagingStatesSequence());
    }

     

    /* private void Start() {
        _currentState = T1Obj;
        _doStuffForCurrentState = T1Obj.OngoingFunctions;
    }

    private void Update() {
        StateFunctionsExecutor();
        ChangeStateTest();
    } */

}
