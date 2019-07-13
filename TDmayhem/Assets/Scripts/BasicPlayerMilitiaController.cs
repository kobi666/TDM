using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMilitiaController : PlayerUnitStateMachine
{
    // Start is called before the first frame update
    class IdleState : StateV2 {
        public new string _name = "IdleState";
        /* public override void OnTriggerStay2dFunctions(PlayerUnitStateMachine.StateObjectsContainer container, UnityEngine.Collider collision) {
            GameUnit EnemyData = collision.gameObject.GetComponent<GameUnit>();
            if (!container.enemyTarget) {
                if (EnemyData.unitIsTargetable() == true) {
                    container.enemyTarget = collision.gameObject;
                }
                 
            }
        } */




        public override IEnumerator OnStateExitFunctions(PlayerUnitStateMachine.UnitDataStructure container) {
            container.cachedPosition = gameObject.transform.position;
            yield return null;
        }


    }

    class MovingToEnemy : StateV2 {
        
    }
    

    void OnTriggerEnter2d(Collider other) {
        //_OnTriggerStay2d_delegate(ObjectsContainer, other);
        if (other.gameObject.GetComponent<GameUnit>().unitIsTargetable() == true) {
            UnitData.enemyTarget = Utils.FindObjectNearestToEndToEndOfSpline(gameObject, "Units");
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<GameUnit>().unitIsTargetable() == true) {
            UnitData.enemyTarget = Utils.FindObjectNearestToEndToEndOfSpline(gameObject, "Units");
        }
    }

    private void Awake() {
        UnitData.SelfGUID = Utils.RandomString(GlobalParameters.Params.Global_GUID_length);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
