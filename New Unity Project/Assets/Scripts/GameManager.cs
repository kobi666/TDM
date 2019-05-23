using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int LifePoints { get; set; }
    public static GameManager Instance;
    [SerializeField] private GeneralTextObject _GeneralTextObject;
    int counter;
    public GameObject[] Paths;
    public GameObject spacedummy;


    public GameManager()
    {
        Instance = this;
    }


    IEnumerator SpawnUnits (int units, float timeBetweenSpawns)
    {
        //Debug.Log("AAAAA");
        counter += 1;
        
        SpawningController.Instance.SpawnUnitWithParams(SpawningController.Instance.Enemies[0], 3.0f, Paths[0], spacedummy.transform.position);
            //Debug.Log("BBBBB");
        
        yield return new WaitForSeconds(timeBetweenSpawns);
        if (counter <= units)
        {
            StartCoroutine(SpawnUnits(units, timeBetweenSpawns));
        }
    }



    private void Awake()
    {
        LifePoints = 20;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnUnits(10, 1.0f));
        //SpawningController.Instance.SpawnUnitWithParams(SpawningController.Instance.Enemies[0], 10.0f, Paths[0], Paths[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(LifePoints);
        GeneralTextObject.Instance.changeText("Life Points : " + GameManager.Instance.LifePoints.ToString());
        //Debug.Log("Spline length : " + Paths[0].GetComponent<BezierSolution.BezierSpline>().Length.ToString());
    }
}
