using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUtils : MonoBehaviour
{
    

    public int GlobalGUID_Length = 5;

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


    public static GameObject FindObjectNearestToEndToEndOfSpline (GameObject GO, string GOType)
    {
        GameObject TargetGO = null;
        float Proximity = 999.0f;
        Collider2D[] Collisions = Physics2D.OverlapCircleAll(GO.transform.position, GO.GetComponent<CircleCollider2D>().radius - 0.2f, 1 << LayerMask.NameToLayer(GOType));
        foreach (Collider2D collision in Collisions)
        {
            if (collision.GetComponent<BezierSolution.EnemyWalker2D>().ProximityToEndOfSpline < Proximity)
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

    public void StopEnemyFromMoving(GameObject TargetEnemy)
    {
        TargetEnemy.GetComponent<BezierSolution.EnemyWalker2D>().InStopEvent = true;
    }

    /* void moveToEnemy (GameObject TargetEnemy, Vector2 TargetEnemyColliderBounds)
    {
        Vector2 EnemyLeftColliderBounds;
        EnemyLeftColliderBounds = new Vector2(TargetEnemyColliderBounds.min.x - (SelfColliderBounds.max.x - SelfColliderBounds.center.x), TargetEnemyColliderBounds.min.y + (SelfColliderBounds.center.y - SelfColliderBounds.min.y));
        transform.position = Vector2.MoveTowards(transform.position, EnemyLeftColliderBounds, Time.deltaTime * speed);
    } */
    /* public void FindRectangleBox() {
        transform.Find("UnitRectBox").GetComponent<SpriteRectangleColliderData>();
    } */

    public static SpriteRectangleColliderData GetSpriteColliderData (GameObject GO) {
        SpriteRectangleColliderData SpriteColliderData;
        return SpriteColliderData = GO.transform.Find("UnitRectBox").GetComponent<SpriteRectangleColliderData>();
    }

    public static Vector2 LeftOfEnemyPositionRelativeToSelfSpriteColliderSize(SpriteRectangleColliderData SelfSpriteCollider, GameObject TargetGO) {

        Bounds EnemyBounds = TargetGO.GetComponent<Collider2D>().bounds;
        Bounds SelfBounds = SelfSpriteCollider.GetRectBoxColliderBounds;
        Vector2 Position = new Vector2(EnemyBounds.min.x - (SelfBounds.max.x - SelfBounds.center.x), EnemyBounds.min.y + (SelfBounds.center.y - SelfBounds.min.y));        
        return Position;
    }

    public static bool ComparePositionToVector2 (Transform _transform, Vector2 _vector2) {
        if (_transform.position.x == _vector2.x && _transform.position.y == _vector2.y) {
            return true;
        }
        else {
            return false;
        }
    }

    public static void MoveUnitToBottomLeftSideOfEnemy(SpriteRectangleColliderData SelfSpriteCollider, GameObject EnemyGO, GameObject ThisGO, float speed) {
        ThisGO.transform.position = Vector2.MoveTowards(ThisGO.transform.position, UnitUtils.LeftOfEnemyPositionRelativeToSelfSpriteColliderSize(SelfSpriteCollider, EnemyGO) , Time.deltaTime * speed);
    }


    public void RandomString(string GUID) {
        const string chars =  "0123456789abcdefghijklmnopqrstuvwxABCDEFGHIJKLMNOPQRSTUVWXYZ";
        GUID = "";
        for (int i = 0 ; i >= GlobalGUID_Length ; i++) {
            int r = Random.Range(0, chars.Length);
            GUID += chars[r];
        }
        
    } 

    /* public string RandomString(int StringLength) {
        const string chars =  "0123456789abcdefghijklmnopqrstuvwxABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";
        for (int i = 0 ; i >= StringLength ; i++) {
            int r = Random.Range(0, chars.Length);
            result += chars[r];
        }
        return result;
    } */

    
}
