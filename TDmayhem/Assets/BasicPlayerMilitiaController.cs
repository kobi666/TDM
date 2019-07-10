using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMilitiaController : PlayerUnitStateMachine
{
    // Start is called before the first frame update
    class IdleState : StateV2 {
        public new string _name = "IdleState";
        public override void OnTriggerStay2dFunctions(PlayerUnitStateMachine.StateObjectsContainer container, UnityEngine.Collider collision) {
            GameUnit GUdata = collision.gameObject.GetComponent<GameUnit>();
            if (!container.enemyTarget) {
                if (GUdata)
                 
            }
        }

    }
    public new class StateObjectsContainer {
        
    }

    void OnTriggerEnter2d(Collider other) {
        _OnTriggerStay2d_delegate(ObjectsContainer);
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
