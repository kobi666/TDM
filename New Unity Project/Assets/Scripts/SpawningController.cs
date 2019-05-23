using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{


    public static SpawningController Instance;

    public GameObject[] Enemies;
    private GameObject SplineParent;

    public SpawningController()
    {
        Instance = this;
    }

    public void basicSpawn(GameObject EnemyPrefab)
    {
        GameObject newEnemy =  Instantiate(EnemyPrefab, this.gameObject.transform.position, Quaternion.identity);
        BezierSolution.BezierSpline newEnemySpline =  newEnemy.GetComponent<BezierSolution.EnemyWalker2D>().spline = SplineParent.GetComponent<BezierSolution.BezierSpline>();
        newEnemy.GetComponent<GameUnitObject>().speed = 5;
    }

    public void SpawnUnitWithParams(GameObject UnitPrefab, float speed, GameObject SplineParentObj, Vector2 targetPosition)
    {
        GameObject newUnit = Instantiate(UnitPrefab, targetPosition, Quaternion.identity);
        newUnit.GetComponent<BezierSolution.EnemyWalker2D>().spline = SplineParentObj.GetComponent<BezierSolution.BezierSpline>();
        newUnit.GetComponent<GameUnitObject>().speed = speed;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        SplineParent = transform.parent.gameObject;
        //basicSpawn(Enemies[0]);
        //SpawnUnitWithParams(Enemies[0], 6.0f, transform.parent.gameObject, transform.position);
    }

}
