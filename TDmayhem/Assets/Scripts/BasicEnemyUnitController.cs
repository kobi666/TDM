using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyUnitController : StateMachine
{
        private BezierSolution.EnemyWalker2D WalkerOBJ;
        string[] stateStrings = {"Walking", "WaitForBattle", "Dead", "InBattle", "Spawning", "Shooting"};
        
        public GameUnit gameUnit;
        
    
        
        public override void virtualInStateFunctions() 
        {
            string CS = CurrentState.stateName;
            if (CS == "Walking") {

            }
            if (CS == "Dead") {

            }
            if (CS == "InBattle") {

            }
        }

        public override void virtualTransitionFunction() 
        {

        }


        private void Awake() 
        {
            WalkerOBJ = gameObject.GetComponent<BezierSolution.EnemyWalker2D>();
            setState("Walking");
        }
        



        void HorizontalFlipper(bool HorizontalDirection)
        {
            if (HorizontalDirection == true)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            gameUnit = gameObject.GetComponent<GameUnit>();
            
            
        }

        // Update is called once per frame
        void Update()
        {
            HorizontalFlipper(gameObject.GetComponent<BezierSolution.EnemyWalker2D>().Hdirection);
            
        }
}
