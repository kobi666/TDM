using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateV2 : MonoBehaviour
{

        public string _name {get {return _name;}  set {_name = value;}}

        public virtual void OngoingFunctions(StateMachineV2.StateObjectsContainer container) { Debug.Log("EMPTY ONGOING Function called");}
        
        public virtual IEnumerator OnStateEnterFunctions(StateMachineV2.StateObjectsContainer container) {Debug.Log("EMPTY ENTER state routine called") ;  yield return null;}

        public virtual IEnumerator OnStateExitFunctions(StateMachineV2.StateObjectsContainer container) {Debug.Log("EMPTY EXIT state routine called") ; yield return null;}
        
        public StateV2(string StateName) {
            _name = StateName;
        }
    
}
