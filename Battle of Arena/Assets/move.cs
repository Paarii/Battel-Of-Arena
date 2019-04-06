using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    // Use this for initialization
    public float speed;
    private Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveh = Input.GetAxis ("Horizontal");
        float movev = Input.GetAxis("Verticle");
        Vector3 movement = new Vector3(moveh, 0.0f, movev);

        rb.AddForce(movement * speed);

    }
   
}
