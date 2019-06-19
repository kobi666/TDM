using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    GameObject EnemyTarget;
    public float Damage;
    public float AttackRate;
    public Vector2 CachedPosition;
    public float speed;
    public float RightSpriteBoundSize;
    public float EnemyBottomSpriteBoundSize;
    public Bounds TargetEnemyColliderBounds;
    GameObject UnitRectCollider;
    public Bounds SelfColliderBounds;

    
    
    
        


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!EnemyTarget)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                EnemyTarget = collision.gameObject;
            }
        }
    }

    

    void StopEnemyFromMoving(GameObject TargetEnemy)
    {
        TargetEnemy.GetComponent<BezierSolution.EnemyWalker2D>().InStopEvent = true;
    }

    void moveToEnemy (GameObject TargetEnemy)
    {
        Vector2 EnemyLeftColliderBounds;
        EnemyLeftColliderBounds = new Vector2(TargetEnemyColliderBounds.min.x - (SelfColliderBounds.max.x - SelfColliderBounds.center.x), TargetEnemyColliderBounds.min.y + (SelfColliderBounds.center.y - SelfColliderBounds.min.y));
        transform.position = Vector2.MoveTowards(transform.position, EnemyLeftColliderBounds, Time.deltaTime * speed);
    }

    





    // Start is called before the first frame update
    void Start()
    {
        UnitRectCollider = transform.Find("UnitRectBox").gameObject;
        SelfColliderBounds = UnitRectCollider.GetComponent<BoxCollider2D>().bounds;
        //Debug.Log("Unit Max vector 2 collider : " + gameObject.GetComponent<Collider2D>().bounds.max.x + " , "  + gameObject.GetComponent<Collider2D>().bounds.max.y);
        //Debug.Log("Unit Min vector 2 collider : " + gameObject.GetComponent<Collider2D>().bounds.min.x + " , " + gameObject.GetComponent<Collider2D>().bounds.min.y);
        RightSpriteBoundSize = GetComponent<SpriteRenderer>().bounds.max.x - GetComponent<SpriteRenderer>().bounds.center.x; 
        CachedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyTarget)
        {
            TargetEnemyColliderBounds = EnemyTarget.GetComponent<Collider2D>().bounds;
            StopEnemyFromMoving(EnemyTarget);
            moveToEnemy(EnemyTarget);
        }

        Utils.PrintSomething("asasdasd");
    }
}
