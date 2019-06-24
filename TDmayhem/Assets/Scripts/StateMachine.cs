using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    
    public class state {
        bool Enabled = false;

        public bool enabled {
            get {return Enabled ;}
            set {Enabled = value;}
        }
        string StateName {get ; set ;} = "Empty state";
        public string stateName {
            get {return StateName ;}
            set {StateName = value ;}
        }
        public state (string stateName) 
        {
            StateName = stateName;
        }

        
    }

    
    public state[] states;

    private state currentState;

    public state CurrentState { get => currentState; set => currentState = value; }

    public void AddStates(string[] _stateNames) {
        
        for (int _state = 0  ; _state == _stateNames.Length -1 ; _state++ ) {
            if (_stateNames[_state] == null) {
                Debug.Log("Null value inserted to states array");
                continue;
                
            }
            states[_state] = new state(_stateNames[_state]);
        }

    
    }

    void setState(string newState) {
        for (int _state = 0 ; _state == states.Length ; _state++) {
            if (states[_state].stateName == newState) {
                states[_state].enabled = true;
                CurrentState = states[_state];
                for (int __state = 0 ; __state == states.Length ; __state++) {
                    if (states[__state].stateName != newState) {
                        states[__state].enabled = false;
                    }
                
                }
            }    
        }
    }
    private IEnumerator StartTransitionCoroutine() {
        virtualTransitionFunction();
        yield return null;
    }

    public IEnumerator StartTransitionToNextState(string _newState) {
        yield return StartCoroutine(StartTransitionCoroutine());
        setState(_newState);
        Debug.Log("state changed to " + _newState + " for " + this.gameObject.name);
    }

    // Write function for each state in the states array for both InStateFunctions and virtualTranstionFunction!!
    public virtual void virtualInStateFunctions () { Debug.Log("Empty virtual function called"); }

    public virtual void virtualTransitionFunction() 
    {
        Debug.Log("Empty virtual function called"); 
    }
        

       
    
}
