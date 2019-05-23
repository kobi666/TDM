using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMTest : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] GameObject[] UnitsInrange;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Target && collision.gameObject.tag == "Enemy")
        {
            Target = collision.gameObject;
        }
    }

    delegate void CombatSequence();
    

    

    void TestFunction()
    {
        Debug.Log("TESTTT");
    }

    public enum States
    {
        IDLE,
        COMBAT,
        DEATH,
    };

    public States Currentstate;

    

    void StateManager ()
    {
        switch(Currentstate)
        {
            case States.IDLE:
                if (Target)
                {
                    Currentstate = States.COMBAT;
                }

                break;
            case States.COMBAT:
                Debug.Log(Currentstate.ToString());
                break;
            case States.DEATH:
                Debug.Log(Currentstate.ToString());
                break;
        }
    }


    
    

    



// Start is called before the first frame update
void Start()
    {
        //CombatSequence = TestFunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
