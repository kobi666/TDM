using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{

    //public static Utils Instance;
    // Start is called before the first frame update


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


    public static GameObject FindObjectNearestToEndToEndOfSpline (GameObject GO, string GoTag, string GOType)
    {
        GameObject TargetGO = null;
        float Proximity = 999.0f;
        Collider2D[] Collisions = Physics2D.OverlapCircleAll(GO.transform.position, GO.GetComponent<CircleCollider2D>().radius - 0.2f, 1 << LayerMask.NameToLayer(GOType));
        foreach (Collider2D collision in Collisions)
        {
            if (collision.gameObject.tag == GoTag && collision.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline < Proximity)
            {
                TargetGO = collision.gameObject;
                Proximity = collision.gameObject.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline;
            }
        }
        return TargetGO;
    }

    public static void PrintSomething(string something)
    {
        Debug.Log(something);
    }

    
}
