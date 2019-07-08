using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMilitiaController : StateMachineV2
{       
    public bool TestBool = true;
    public delegate void OngoingDelegateFunctionToRunInsideOnTriggerEnter2D();
    OngoingDelegateFunctionToRunInsideOnTriggerEnter2D _ongoingDelegateFunctionToRunInsideOnTriggerEnter2D;

    /* public delegate IEnumerator StateTransitionDelegateFunctionToRunInsideOnTriggerEnter2D();
    StateTransitionDelegateFunctionToRunInsideOnTriggerEnter2D _stateTransitionDelegateFunctionToRunInsideOnTriggerEnter2D; */

    

    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    


    public class PlayerUnitIdleState : StateV2 {
        
        public override void OngoingFunctions() {
            
        }
        public override IEnumerator OnStateEnterFunctions() {
            Debug.Log("Entered Idle State");
            yield return null;
            
        }

        public override IEnumerator OnStateExitFunctions() {
            Debug.Log("Exited Idle State");
            yield return null;
        }
 
    }

    

    

    
    
    

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
