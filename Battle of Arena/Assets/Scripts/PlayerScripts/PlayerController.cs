using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpforce;
    private Rigidbody rb;
    private bool isgrounded;
    public int extrajump;
    public float downforce = 100f;
    public KeyCode presskey;
    public KeyCode presskey2;
    public KeyCode presskey3;
    private bool facingright;
    public float gravity = 14.01f;
    public guncontroller thegun;
    public float Damage = 0;
    public AudioSource source;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        facingright = false;
        source = GetComponent<AudioSource>();
    }

    
    private void FixedUpdate()
    {
  
        
        
        float xspeed = Input.GetAxis("Horizontal");
        //float yspeed = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xspeed,0.0f, 0.0f);
        rb.AddRelativeForce(movement * speed);
        
       if(xspeed > 0 && facingright)
        {
            Debug.Log("I flipped righrt");
            Flip();
        }
        else if(xspeed < 0 && !facingright)
        {
            //Debug.Log("I flipped another side");
            Flip();
            rb.AddForce(movement * speed * 10, ForceMode.Acceleration);

        }

        RaycastHit hit;
        Vector3 physicscenter = this.transform.position + this.GetComponent<SphereCollider>().center;
        Debug.DrawRay(physicscenter,Vector3.down,Color.red, 1);
        if(Physics.Raycast(physicscenter,Vector3.down,out hit,1))
        {
            if(hit.transform.gameObject.tag != "Player")
            {
                isgrounded = true;
            }
        }
        else
        {
            isgrounded = false;
        }
       
        if(isgrounded == true)
        {
            extrajump = 2;
        }
        if (Input.GetKeyDown(KeyCode.W)&& extrajump > 0)
        {
            this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * jumpforce, ForceMode.Impulse);
            extrajump--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && isgrounded && extrajump== 0)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpforce,  ForceMode.Impulse );
            extrajump = 2;
        }
        else if(Input.GetKey(KeyCode.S) && !isgrounded)
        {
            Debug.Log("going down");
            this.GetComponent<Rigidbody>().AddForce(Vector3.down * downforce);
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Space Hits");
            thegun.isfiring = true;
            source.Play();
        }
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Fire1"))
        {
            thegun.isfiring = false;
        }

     
    }
    void Flip()
    {
        facingright = !facingright;
        Vector3 scale = transform.localScale ;
        Debug.Log(scale.x);

        scale.x *= -1;
        transform.localScale = scale;
    }


}
