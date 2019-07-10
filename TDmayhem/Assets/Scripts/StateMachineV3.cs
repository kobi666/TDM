using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineV3 : MonoBehaviour
{
    // Start is called before the first frame update
   
   List<string> states;

    string CurrentState {
        get {
            return CurrentState;
        }
        set {
            if (states.Contains(value)) {
                CurrentState = value;
            }
            else
            {
                CurrentState = CurrentState;
                Debug.Log("Illeagel assignment of CURRENT state: " + value);
            }
        }
    }

    string LastState {
        get {
            return LastState;
        }
        set {
            if (states.Contains(value)) {
                LastState = value;
            }
            else
            {
                LastState = LastState;
                Debug.Log("Illeagel assignment of LAST state: " + value);
            }
        }
    }


    

    string NextState {
        get {
            return NextState;
        }
        set {
            if (states.Contains(value)) {
                NextState = value;
            }
            else
            {
                NextState = NextState;
                Debug.Log("Illeagel assignment of NEXT state: " + value);
            }
        }
    }

    private bool stopDoingThingsWhileTransitioningToNewState = false;
    public bool StopDoingThingsWhileTransitioningToNewState { get => stopDoingThingsWhileTransitioningToNewState; set => stopDoingThingsWhileTransitioningToNewState = value; }

    public delegate void RunningStateFunctions();
    RunningStateFunctions _RunningStateFunctions;
    public delegate IEnumerator EnterStateFunctions();
    EnterStateFunctions _EnterStateFunctions;
    public delegate IEnumerator ExitStateFunctions();
    ExitStateFunctions _ExitStateFunctions;

    public IEnumerator StartChangeStateSequence() {
        yield return StartCoroutine(_ExitStateFunctions());
        yield return StartCoroutine(_EnterStateFunctions());
        StopDoingThingsWhileTransitioningToNewState = false;
    }

    void OnStateChangeFunctionSwitcher() {

    }

    void SetInitialState() {

    }

    

    
}
