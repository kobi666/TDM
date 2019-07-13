using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateV2 : MonoBehaviour
{

        public string _name {get {return _name;}  set {_name = value;}}

        public virtual void OngoingFunctions(PlayerUnitStateMachine.UnitDataStructure container) { Debug.Log("EMPTY ONGOING Function called");}
        public virtual void OnTriggerStay2dFunctions(PlayerUnitStateMachine.UnitDataStructure container, UnityEngine.Collider collision) { Debug.Log("EMPTY ONTRIGGERSTAY2D Function called");}
        
        public virtual IEnumerator OnStateEnterFunctions(PlayerUnitStateMachine.UnitDataStructure container) {Debug.Log("EMPTY ENTER state routine called") ;  yield return null;}

        public virtual IEnumerator OnStateExitFunctions(PlayerUnitStateMachine.UnitDataStructure container) {Debug.Log("EMPTY EXIT state routine called") ; yield return null;}
        
        
    
}
