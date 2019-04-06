using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller : MonoBehaviour {
    public float speed;
    // Use this for initialization
    public GameObject hitimpact;
    public ChargeScript charge;
    public float DestroyTimeDelay;
    public CameraShake camerashake;
    public AudioSource source;
    
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("i hit");
        Destroy(gameObject);
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        if(hitimpact != null)
        {
            source.Play();
            var newhit = Instantiate(hitimpact, pos, rot);
            
            Destroy(gameObject, DestroyTimeDelay);
          

        }
    }
}
