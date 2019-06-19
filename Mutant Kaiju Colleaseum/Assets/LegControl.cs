using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LegControl : MonoBehaviour
{
    Rigidbody2D RB;
    public float moveSpeed;

    // Start is called before the first frame update
    private void Awake() {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }


    void LegMovement() {
        if (RB) {
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");

            float xForce = xInput * moveSpeed * Time.deltaTime * 300;
            float yForce = yInput * moveSpeed * Time.deltaTime * 500;
            Vector2 force = new Vector2(xForce,yForce   );

            
            RB.AddForce(force);
            Debug.Log(force.ToString());
        }
        else
        {
            Debug.Log("No RigidBody 2d");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LegMovement();
    }
}
