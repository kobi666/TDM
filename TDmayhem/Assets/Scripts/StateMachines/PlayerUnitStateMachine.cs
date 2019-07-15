using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitStateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Dictionary<string, StateV2> states;

    [System.Serializable]
    public class UnitDataStructure {
        public string SelfGUID;
        public SpriteRectangleColliderData SelfSpriteCollider;
        public GameObject SelfUnitRectangleBox;
        public GameObject enemyTarget;
        public float damage;
        public float attackRate;
        public Vector2 cachedPosition;
        public float speed;
        public float rightSpriteBoundSize;
        public float enemyBottomSpriteBoundSize;
        public Bounds targetEnemyColliderBounds;
        
    }
    
    public UnitDataStructure UnitData;

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

    

    public delegate void Ontrigger2D_DelegateFunction(PlayerUnitStateMachine.UnitDataStructure container, UnityEngine.Collider collision);
    public Ontrigger2D_DelegateFunction _OnTriggerStay2d_delegate;
    Ontrigger2D_DelegateFunction _OnTriggerEnter2d_delegate;
    Ontrigger2D_DelegateFunction _OnTriggerExit2d_delegate;
    


    public StateV2 NewState;
    public StateV2 OldState;
    public StateV2 _currentState;

    public delegate void DelegateCurrentBehavior();
    DelegateCurrentBehavior _delegateCurrentBehavior;

    public delegate IEnumerator DoStuffWhenEnteringToNewState(UnitDataStructure container);
    public delegate IEnumerator DoStuffWhenExitingFromOldState(UnitDataStructure container);
    public delegate void DoStuffForTheCurrentState(UnitDataStructure container);

    DoStuffForTheCurrentState _doStuffForCurrentState;
    DoStuffWhenEnteringToNewState _doStuffWhenEnteringToNewState;
    DoStuffWhenExitingFromOldState _doStuffWhenExitingFromOldState;

    public IEnumerator StartExitFromOldStateSequence() {
        yield return StartCoroutine(_doStuffWhenExitingFromOldState(UnitData));
    }

    public IEnumerator StartEnteringToNewStateSequence() {
        yield return StartCoroutine(_doStuffWhenEnteringToNewState(UnitData));
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


    private void Awake() {
        
    }




    public void StateFunctionsExecutor() {
        
        if (StopDoingThingsWhileTransitioningToNewState == false) {
            _doStuffForCurrentState(UnitData);
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
