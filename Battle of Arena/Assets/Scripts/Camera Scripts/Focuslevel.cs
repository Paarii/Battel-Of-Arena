using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focuslevel : MonoBehaviour {

    public float halfxbound = 20f;
    public float halfybounds = 15f;
    public float halfzbounds = 15f;

    public Bounds halfbounds;
	// Update is called once per frame
	void Update () {
        Vector3 pos = gameObject.transform.position;
        Bounds bounds = new Bounds();
        bounds.Encapsulate(new Vector3(pos.x - halfxbound, pos.y - halfybounds, pos.z - halfzbounds));
        bounds.Encapsulate(new Vector3(pos.x + halfxbound, pos.y + halfybounds, pos.z + halfzbounds));
        halfbounds = bounds;
        

    }
}
