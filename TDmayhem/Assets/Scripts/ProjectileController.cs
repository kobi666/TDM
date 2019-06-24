using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public int[] DamageRange;
    public float speed;
    Vector2 OriginPosition;
    float LiveProgressToTarget;
    float TotalDistanceToTarget;
    public float archAmount;
    public Vector2 CachedTargetPosition;
    float ProgressRelativeToDistance;

    

    

    public GameObject Target;
    // Start is called before the first frame update

    void MoveToTarget ()
    {
        if (Target)
        {
            //Debug.Log((transform.position, Target.transform.position, Time.deltaTime * speed).ToString());
            transform.position = Vector2.MoveTowards(transform.position, CachedTargetPosition, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Target)
        {
            //Target.GetComponent<GameUnitObject>().LifePoints -= Random.Range(DamageRange[0], DamageRange[1]);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OriginPosition = transform.position;
        CachedTargetPosition = Target.transform.position;
        TotalDistanceToTarget = Vector2.Distance(OriginPosition, CachedTargetPosition);
    }



    // Update is called once per frame
    void Update()
    {
        LiveProgressToTarget = Vector2.Distance(transform.position, CachedTargetPosition);
        ProgressRelativeToDistance = LiveProgressToTarget / TotalDistanceToTarget;
        //Debug.Log("Live Distance to target : " + LiveProgressToTarget +  "  And Progress to target :" + ProgressRelativeToDistance);

        if (ProgressRelativeToDistance <= 0)
        {
            Destroy(gameObject);
        }


        MoveToTarget();
        
        if (new Vector2(transform.position.x, transform.position.y)  == CachedTargetPosition)
            {
            Destroy(gameObject);
            }
        

        if (Target == null)
        {
            Destroy(gameObject);
        }

    }
}
