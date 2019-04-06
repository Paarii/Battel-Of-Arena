using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveprojectile : MonoBehaviour {
    public float speed;
    public float firerate;
    public GameObject playerposition;
    public Transform pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(speed != 0)
        {
            
                Debug.Log("Fired left");
            transform.position = transform.forward * speed * Time.deltaTime;
            
        }
        else
        {
            Debug.Log("No speed");
        }
	}
}
