using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guncontroller : MonoBehaviour {

    // Use this for initialization
    public bool isfiring;
    public GameObject bullet;
    public GameObject Muzzle;
    public bulletcontroller bullet2;
    public float bulletspeed;
    public float timebtwshots;
    private float shotcounter;
    public Transform firepoint;
    public Transform Muzzlepoint;
   
	
	// Update is called once per frame
	void Update () {
		if(isfiring)
        {
            shotcounter -= Time.deltaTime;
            if(shotcounter <= 0)
            {
                shotcounter = timebtwshots - Time.deltaTime;
               
                GameObject newebullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as GameObject ;
                GameObject newmuzzle = Instantiate(Muzzle, Muzzlepoint.position, Muzzlepoint.rotation) as GameObject as GameObject;
              
                bullet2.speed = bulletspeed;
            }
        }
        else
        {
            shotcounter = 0;
        }
	}
}
