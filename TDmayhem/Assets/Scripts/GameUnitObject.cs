using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnitObject : MonoBehaviour
{
    private BezierSolution.EnemyWalker2D WalkerOBJ;
    public bool isEnemy { get; set; }
    public bool DamageToPlayerOnContact { get; set; }
    public float speed;
    public float ProximityToEndOfSpline;
    // Start is called before the first frame update
    bool Hdirection;

    private void Awake()
    {
        
    }

    

    void FlipAnimationAgent()
    {
        if (Hdirection == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }




    void DestroyObjectOnLifeloss()
    {
        if (LifePoints <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        if (gameObject.tag == "Enemy")
            {
            if (speed != 0)
                {
                WalkerOBJ = GetComponent<BezierSolution.EnemyWalker2D>();
                WalkerOBJ.speed = speed;
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Enemy")
        {
            Hdirection = GetComponent<BezierSolution.EnemyWalker2D>().Hdirection;
            FlipAnimationAgent();
        }

        DestroyObjectOnLifeloss();
    }
}
