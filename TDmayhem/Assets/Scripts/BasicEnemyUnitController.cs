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
            if (CS == "WaitForBattle") {

            }
        }

        public override void virtualTransitionFunction(string _newState) 
        {
            string CachedState = CurrentState.stateName;
            if (_newState == "Walking") {

            }
            if (_newState == "Dead") {

            }
            if (_newState == "InBattle") {

            }
            if (_newState == "WaitForBattle") {
                
            }
        }


        private void Awake() 
        {
            setState("Walking");
            WalkerOBJ = gameObject.GetComponent<BezierSolution.EnemyWalker2D>();
            gameUnit = gameObject.GetComponent<GameUnit>();
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
            
            
        }

        // Update is called once per frame
        void Update()
        {
            HorizontalFlipper(gameObject.GetComponent<BezierSolution.EnemyWalker2D>().Hdirection);
            if (!RuntimeStateLock) {
                virtualInStateFunctions();
            }
        }
}
