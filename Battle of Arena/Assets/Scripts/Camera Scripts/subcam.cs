using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subcam : MonoBehaviour {

    // Use this for initialization
    public Focuslevel focuslevel;
    public List<GameObject> Players;
    public float depthupdatespeed = 5f;
    public float angleupdatespeed = 7f;
    public float positionupdatespeed = 5f;
    public float depthmax = -10f;
    public float depthmin = -22f;
    public float anglemax = 11f;
    public float anglemin = 3f;

    public float cameraEuslerx;
    private Vector3 cameraposition;



    void Start () {

        Players.Add(focuslevel.gameObject);

	}
	
	// Update is called once per frame
	void LateUpdate () {
        calculatecameralocation();
        movecamera();
	}

    void movecamera()
    {
        Vector3 pos = gameObject.transform.position;
        if(pos != cameraposition)
        {
            Vector3 newpos = Vector3.zero;
            newpos.x = Mathf.MoveTowards(pos.x, cameraposition.x, positionupdatespeed * Time.deltaTime);
            newpos.y = Mathf.MoveTowards(pos.y, cameraposition.y, positionupdatespeed * Time.deltaTime);
            newpos.z = Mathf.MoveTowards(pos.z, cameraposition.y, depthupdatespeed * Time.deltaTime);
            gameObject.transform.position = newpos;
        }

        Vector3 localeulerangles = gameObject.transform.localEulerAngles;
        if(localeulerangles.x != cameraEuslerx)
        {
            Vector3 targereulerangles = new Vector3(cameraEuslerx, localeulerangles.y, localeulerangles.z);
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(localeulerangles, targereulerangles, angleupdatespeed * Time.deltaTime);
        }
    }

    void calculatecameralocation()
    {
        Vector3 averagecenter = Vector3.zero;
        Vector3 totalpos = Vector3.zero;
        Bounds playerbounds = new Bounds();

        for(int i = 0; i < Players.Count; i++)
        {
            Vector3 playerpostion = Players[i].transform.position;
            if(!focuslevel.halfbounds.Contains(playerpostion))
            {
                float playerx = Mathf.Clamp(playerpostion.x, focuslevel.halfbounds.min.x, focuslevel.halfbounds.max.x);
                float playery = Mathf.Clamp(playerpostion.y, focuslevel.halfbounds.min.y, focuslevel.halfbounds.max.y);
                float playerz = Mathf.Clamp(playerpostion.z, focuslevel.halfbounds.min.z, focuslevel.halfbounds.max.z);
                playerpostion = new Vector3(playerx, playery, playerz);
            }
            totalpos += playerpostion;
            playerbounds.Encapsulate(playerpostion);
        }

        averagecenter = (totalpos / Players.Count);
        float extents = (playerbounds.extents.x + playerbounds.extents.y);
        float lerppersent = Mathf.InverseLerp(0, (focuslevel.halfxbound + focuslevel.halfybounds) / 2, extents);
        float depth = Mathf.Lerp(depthmax, depthmin, lerppersent);
        float angle = Mathf.Lerp(anglemax, anglemin, lerppersent);

        cameraEuslerx = angle;
        cameraposition = new Vector3(averagecenter.x, averagecenter.y, depth);

    }
}
