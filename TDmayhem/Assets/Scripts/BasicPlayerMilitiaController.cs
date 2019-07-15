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
        public override void OngoingFunctions(UnitDataStructure container) {
            if (UnitUtils.ComparePositionToVector2(this.gameObject.transform, UnitUtils.LeftOfEnemyPositionRelativeToSelfSpriteColliderSize(container.SelfSpriteCollider, container.enemyTarget)) == false) {
                UnitUtils.MoveUnitToLeftSideOfEnemy(container.SelfSpriteCollider, container.enemyTarget, this.gameObject, container.speed);
            }
            
        }


        //continue this

        public override IEnumerator OnStateEnterFunctions(UnitDataStructure container) {
            yield return null;
        }
    }   

    
    
    

    void OnTriggerEnter2d(Collider other) {
        //_OnTriggerStay2d_delegate(ObjectsContainer, other);
        if (other.gameObject.GetComponent<GameUnit>().unitIsTargetable() == true) {
            UnitData.enemyTarget = UnitUtils.FindObjectNearestToEndToEndOfSpline(gameObject, "Units");
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<GameUnit>().unitIsTargetable() == true) {
            UnitData.enemyTarget = UnitUtils.FindObjectNearestToEndToEndOfSpline(gameObject, "Units");
        }
    }

    private void Awake() {
        //UnitData.SelfGUID = Utils.RandomString(UnitData.SelfGUID);
    }

    void Start()
    {
        UnitData.cachedPosition = transform.position;
        UnitData.SelfSpriteCollider = UnitUtils.GetSpriteColliderData(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
