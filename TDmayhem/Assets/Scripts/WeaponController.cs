using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public float FireRate;
    float FireRateTimer;
    public GameObject Projectile;
    private GameObject Target;
    private LineRenderer LineRend;
    Vector3[] Points = new Vector3[2];


    //void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy" && FireRateTimer <= 0)
    //    {
    //        Target = Utils.FindObjectNearestToEndToEndOfSpline(gameObject, "Enemy", "Units");
    //        //Debug.Log(gameObject.name + " Enemy detected");

    //        //Debug.Log(collision.gameObject.GetInstanceID().ToString() + " : " + collision.gameObject.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline);
    //        //Debug.Log(Target.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline);
            

    //    }
    //}

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy" && FireRateTimer <= 0)
    //    {
    //        Target = Utils.FindObjectNearestToEndToEndOfSpline(gameObject, "Enemy", "Units");
    //        //Debug.Log(gameObject.name + " Enemy detected");

    //        //Debug.Log(collision.gameObject.GetInstanceID().ToString() + " : " + collision.gameObject.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline);
    //        //Debug.Log(Target.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline);
    //        Debug.Log(Target.GetInstanceID().ToString());
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy" && FireRateTimer <= 0)
    //    {
    //        Target = Utils.FindObjectNearestToEndToEndOfSpline(gameObject, "Enemy", "Units");
    //        Target = null;
    //    }

            
    //    }




    //GameObject FindEnemyNearestToEnd()
    //{        
    //    Collider2D[] Collisions = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
    //    GameObject G = Collisions[0].gameObject;
    //    foreach (Collider2D col in Collisions)
    //    {
    //        if (col.gameObject.tag != "Enemy")
    //        {
    //            continue;
    //        }
    //        if (G.tag != "Enemy")
    //        {
    //            G = col.gameObject;
    //        }
    //        if (col.gameObject.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline < G.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline)
    //        {
    //            G = col.gameObject;
    //        }
    //    }
    //    return G;
        
    //}

    
    


    void FireProjectileWeapon (GameObject Target)
    {
        GameObject projectile = Instantiate(Projectile, this.gameObject.transform.position, Quaternion.identity);
        projectile.GetComponent<ProjectileController>().Target = Target;
        FireRateTimer = FireRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        FireRateTimer = FireRate;
        LineRend = GetComponent<LineRenderer>();
        Points[0] = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(FireRateTimer <= 0)
        { 
        Target = UnitUtils.FindObjectNearestToEndToEndOfSpline(gameObject, "Units");
        }

        if (Target && FireRateTimer <= 0)
        {
            Points[1] = Target.transform.position;
            LineRend.SetPositions(Points);
            FireProjectileWeapon(Target);
            Target = null;
        }
        
        FireRateTimer -= Time.deltaTime;
    }
}
