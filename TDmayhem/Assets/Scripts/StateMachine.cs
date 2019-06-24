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

    
    private state[] states ;

    
    

    public void AddStates(string[] _stateNames) {
        
        for (int _state = 0  ; _state == _stateNames.Length -1 ; _state++ ) {
            if (_stateNames[_state] == null) {
                Debug.Log("Null value inserted to states array");
                continue;
                
            }
            states[_state] = new state(_stateNames[_state]);
        }

    
    }

    public void setState(string newState) {
        for (int _state = 0 ; _state == states.Length ; _state++) {
            if (states[_state].stateName == newState) {
                states[_state].enabled = true;
                for (int __state = 0 ; __state == states.Length ; __state++) {
                    if (states[__state].stateName != newState) {
                        states[__state].enabled = false;
                    }
                }
            }    
        }
    }

    public IEnumerator StartTransition(string _newState) {
        yield return StartCoroutine(transitionToNextState());
        setState(_newState);
    }

    

    

    

    


    public virtual void inStateFunctions () { Debug.Log("Empty virtual function called"); }

    public virtual IEnumerator transitionToNextState() {
        Debug.Log("Empty virtual function called");
        yield return null;
        }
        

       
    
}
