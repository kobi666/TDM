using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMilitiaController : StateMachineV2
{       
    /* public delegate IEnumerator StateTransitionDelegateFunctionToRunInsideOnTriggerEnter2D();
    StateTransitionDelegateFunctionToRunInsideOnTriggerEnter2D _stateTransitionDelegateFunctionToRunInsideOnTriggerEnter2D; */
    [System.Serializable]
    public class PlayerUnitStateObjectsContainer : StateObjectsContainer {
        private GameObject enemyTarget;
        private float damage;
        private float attackRate;
        private Vector2 cachedPosition;
        private float speed;
        private float rightSpriteBoundSize;
        private float enemyBottomSpriteBoundSize;
        private Bounds targetEnemyColliderBounds;
        GameObject UnitRectCollider;
        private Bounds selfColliderBounds;

        public GameObject EnemyTarget { get => enemyTarget; set => enemyTarget = value; }
        public float Damage { get => damage; set => damage = value; }
        public float AttackRate { get => attackRate; set => attackRate = value; }
        public Vector2 CachedPosition { get => cachedPosition; set => cachedPosition = value; }
        public float Speed { get => speed; set => speed = value; }
        public float RightSpriteBoundSize { get => rightSpriteBoundSize; set => rightSpriteBoundSize = value; }
        public float EnemyBottomSpriteBoundSize { get => enemyBottomSpriteBoundSize; set => enemyBottomSpriteBoundSize = value; }
        public Bounds TargetEnemyColliderBounds { get => targetEnemyColliderBounds; set => targetEnemyColliderBounds = value; }
        public GameObject UnitRectCollider1 { get => UnitRectCollider; set => UnitRectCollider = value; }
        public Bounds SelfColliderBounds { get => selfColliderBounds; set => selfColliderBounds = value; }
    }


    

    
    
    

    


    


    public class PlayerUnitIdleState : StateV2 {
        
        public override void OngoingFunctions(StateObjectsContainer container) {
            
        }
        public override IEnumerator OnStateEnterFunctions(StateObjectsContainer container) {
            Debug.Log("Entered Idle State");
            yield return null;
            
        }

        public override IEnumerator OnStateExitFunctions(StateObjectsContainer container) {
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
