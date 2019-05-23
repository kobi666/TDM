using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlotObject : MonoBehaviour
{
    Color[] colors = new Color[3];
    public GameObject[] Towers;


    private void OnMouseUp()
    {
        Debug.Log("Click");
        //GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, 3)];
        InstantiateTower(Towers[0]);
    }

    // Need to find a better way to click on tower slots and towers then relying on negetive Z axis

    void InstantiateTower(GameObject TowerPrefab)
    {
        GameObject NewTower = Instantiate(TowerPrefab, transform.position, Quaternion.identity);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.red;
        colors[1] = Color.blue;
        colors[2] = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
