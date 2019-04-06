using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public Transform pos1;
    public Transform pos2; 
    public IEnumerator Shake (float duration, float magnitude)
    {

        Vector3 orignalpos = transform.localPosition;
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(0, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
            transform.localPosition = orignalpos;
            pos1 = pos2;
            
            
        }
    }
}
