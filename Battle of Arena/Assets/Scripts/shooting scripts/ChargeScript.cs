using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeScript : MonoBehaviour {
    public KeyCode Chargeattack;
    public float chargertime = 0;
    public GameObject ChargeVfx;
    public GameObject fireobject;
    public Transform firepoint;
    public Transform firepoint2;
    public GameObject hitimpact;
    public float chargetimer = 0;
    public AudioSource source;
    public AudioSource source1;
    public AudioSource source2;
    public float knockbackcharge;
    public Transform parentobject;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(Chargeattack))
        {
            var instance = Instantiate(ChargeVfx, firepoint.position, firepoint.rotation) as GameObject;
           // ChargeVfx.transform.parent = parentobject;
            Destroy(instance, chargetimer);
            chargertime += Time.deltaTime;
            

        }
        if(Input.GetKeyDown(Chargeattack))
        {
            source.Play();
        }
        if(Input.GetKeyUp(Chargeattack))
        {
            source.Stop();
        }
        if(Input.GetKeyUp(Chargeattack) && chargertime > 0)
        {
            source.Stop();
            source1.Play();
            var newhit = Instantiate(hitimpact, firepoint.position, firepoint.rotation);
            source2.Play();
            Destroy(newhit, 1);
            var instance2 = Instantiate(fireobject, firepoint2.position, firepoint2.rotation) as GameObject;
            chargertime = 0;
           
            

        }
        if (Input.GetKeyUp(Chargeattack) && chargertime < 2)
        {
            chargertime = 0;
        }
        if(chargertime > 0 && chargertime < 2)
        {
            knockbackcharge = 2f;
        }
        if(chargertime > 2)
        {
            knockbackcharge = 5f;
        }

       
    }
}
