using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitStateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string, StateV2> states;

    [System.Serializable]
    public class StateObjectsContainer {
        public GameObject enemyTarget;
        public float damage;
        public float attackRate;
        public Vector2 cachedPosition;
        public float speed;
        public float rightSpriteBoundSize;
        public float enemyBottomSpriteBoundSize;
        public Bounds targetEnemyColliderBounds;
        public GameObject UnitRectCollider;
        public Bounds selfColliderBounds;
    }
    
    public StateObjectsContainer ObjectsContainer;

    public bool StopDoingThingsWhileTransitioningToNewState {
        get {return StopDoingThingsWhileTransitioningToNewState;}
        set {
            StopDoingThingsWhileTransitioningToNewState = value;
        }
        
    }

    /* public class StateV2{

        public string _name = "EMPTY STATE";

        public virtual void OngoingFunctions(StateObjectsContainer container) { Debug.Log("EMPTY ONGOING Function called");}
        
        public virtual IEnumerator OnStateEnterFunctions(StateObjectsContainer container) {Debug.Log("EMPTY ENTER state routine called") ;  yield return null;}

        public virtual IEnumerator OnStateExitFunctions(StateObjectsContainer container) {Debug.Log("EMPTY EXIT state routine called") ; yield return null;}
    } */

    

    public delegate void Ontrigger2D_DelegateFunction(PlayerUnitStateMachine.StateObjectsContainer container);
    public Ontrigger2D_DelegateFunction _OnTriggerStay2d_delegate;
    Ontrigger2D_DelegateFunction _OnTriggerEnter2d_delegate;
    Ontrigger2D_DelegateFunction _OnTriggerExit2d_delegate;
    


    public StateV2 NewState = new StateV2();
    public StateV2 OldState = new StateV2();
    public StateV2 _currentState = new StateV2();

    public delegate void DelegateCurrentBehavior();
    DelegateCurrentBehavior _delegateCurrentBehavior;

    public delegate IEnumerator DoStuffWhenEnteringToNewState(StateObjectsContainer container);
    public delegate IEnumerator DoStuffWhenExitingFromOldState(StateObjectsContainer container);
    public delegate void DoStuffForTheCurrentState(StateObjectsContainer container);

    DoStuffForTheCurrentState _doStuffForCurrentState;
    DoStuffWhenEnteringToNewState _doStuffWhenEnteringToNewState;
    DoStuffWhenExitingFromOldState _doStuffWhenExitingFromOldState;

    public IEnumerator StartExitFromOldStateSequence() {
        yield return StartCoroutine(_doStuffWhenExitingFromOldState(ObjectsContainer));
    }

    public IEnumerator StartEnteringToNewStateSequence() {
        yield return StartCoroutine(_doStuffWhenEnteringToNewState(ObjectsContainer));
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
            _doStuffForCurrentState(ObjectsContainer);
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
        _OnTriggerStay2d_delegate = _currentState.OnTriggerStay2dFunctions;
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
