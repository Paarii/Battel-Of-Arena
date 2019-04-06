using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class knocknackscript : MonoBehaviour {

    // Use this for initialization
    public float Force = 1f;
    public float Force2 = 1f;
    public CameraShake Camerashake;
    public ChargeScript script;
    public float CHARGE = 0;
    public float damage = 0;
    public Text textcomponent;
    public float healamount;
    public Transform tartget;
    public PlayerController playercontroller;
    public AudioSource source;
    void Start() {
        healamount = UnityEngine.Random.Range(1, 5);
        


    }

    // Update is called once per frame
    void Update() {
        CHARGE = script.knockbackcharge;
        settext();
        healovertime(healamount, 5);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {

            damage += UnityEngine.Random.Range(4.5f, 6.5f);

            //text = damage.ToString();
            Debug.Log("Knockback");
            StartCoroutine(Camerashake.Shake(.7f, 0.23f));
            /*  Vector3 pushdirection = collision.transform.position + transform.position;
              pushdirection = -pushdirection.normalized;
              GetComponent<Rigidbody>().AddForce(pushdirection * Force * 100);*/
            Vector3 scale = transform.localScale;
            if (scale.x == 1)
            {
                Debug.Log("Knockback Right");
                GetComponent<Rigidbody>().AddForce(Vector3.up * Force * 100);
                GetComponent<Rigidbody>().AddForce(Vector3.right * -1 * Force * 100);
            }
            if (scale.x == -1)
            {
                Debug.Log("Knockback left");
                GetComponent<Rigidbody>().AddForce(Vector3.up * Force * 100);
                GetComponent<Rigidbody>().AddForce(Vector3.right * Force * 100);

            }
        }
        if (collision.collider.tag == "Bullet2")
        {
            Debug.Log("Knockback");
            Debug.Log(CHARGE);
            StartCoroutine(Camerashake.Shake(.7f, 0.23f));
            /*  Vector3 pushdirection = collision.transform.position + transform.position;
              pushdirection = -pushdirection.normalized;
              GetComponent<Rigidbody>().AddForce(pushdirection * Force * 100);*/
            Vector3 scale = transform.localScale;
            if (scale.x == 1)
            {
                Debug.Log("Knockback Right");
                if (CHARGE == 2)
                {
                    damage += UnityEngine.Random.Range(4.5f, 6.5f);
                    Debug.Log(damage);
                    GetComponent<Rigidbody>().AddForce(Vector3.up * Force2 * 100);
                    GetComponent<Rigidbody>().AddForce(Vector3.right * -1 * Force2 * 100);
                }
                if (CHARGE == 5)
                {
                    damage += 9;
                    Debug.Log(damage);
                    Debug.Log("double force");
                    GetComponent<Rigidbody>().AddForce(Vector3.up * (Force2 + 2) * 100);
                    GetComponent<Rigidbody>().AddForce(Vector3.right * -1 * (Force2 + 2) * 100);
                }
                Debug.Log("forceee" + Force2);
                if (damage >= 100)
                {
                    Vector3 pos = transform.localPosition;
                    pos.z -= 250;
                   
                    GetComponent<Rigidbody>().AddForce(Vector3.up * (100) * 100);
                    GetComponent<Rigidbody>().AddForce(pos * (150));
                    this.GetComponent<Rigidbody>().AddForce(Vector3.down * 300);
                    Quaternion rotation = transform.localRotation;
                    rotation.z = 25;
                    transform.localRotation = rotation;
                    source.Play();

                }
            }

            if (scale.x == -1)
            {
                Debug.Log("Knockback left");
                if (CHARGE == 2)
                {
                    damage += UnityEngine.Random.Range(4.5f, 6.5f);
                    Debug.Log(damage);
                    GetComponent<Rigidbody>().AddForce(Vector3.up * Force2 * 100);
                    GetComponent<Rigidbody>().AddForce(Vector3.right * Force2 * 100);
                }
                if (CHARGE == 5)
                {
                    damage += 9;
                    Debug.Log(damage);
                    GetComponent<Rigidbody>().AddForce(Vector3.up * (Force2 + 2) * 100);
                    GetComponent<Rigidbody>().AddForce(Vector3.right * -1 * (Force2 + 2) * 100);
                }
                Debug.Log("forceee" + Force2);
            }
            if(damage >= 100)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * (20) * 100);
                GetComponent<Rigidbody>().AddForce(Vector3.right  * (Force2 + 100) * 100);
                Quaternion rotation = transform.localRotation;
                rotation.z = 25;
                transform.localRotation = rotation;
                source.Play();

            }
            Debug.Log("fORCE:" + Force2);

        }


    }

    public  void healovertime(float healamount, int duration)
    {
        if(damage > 110)        
            StartCoroutine(Healovertimecoroutine(healamount, duration));
        
    }

    IEnumerator Healovertimecoroutine(float healamount, int duration)
    {
        float amounthealed = 0;
        float healperloop = healamount / duration;
        while(amounthealed < healamount)
        {
            
            damage -= healperloop;
            amounthealed += healperloop;
            yield return new WaitForSeconds(5f);
        }
    }

    private void settext()
    {
        textcomponent.text = Math.Round(damage, 2,MidpointRounding.AwayFromZero).ToString() + "%";
        
    }
}
