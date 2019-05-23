using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseBeacon : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I reached here");
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Collision happened");
            GameManager.Instance.LifePoints -= 1;
            Destroy(collision.gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("Collision happened");
    //        GameManager.Instance.LifePoints -= 1;
    //        Destroy(collision.gameObject);
    //    }
    //}


    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
