using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Meteor : MonoBehaviour
{
    public GameObject[] EffectsOnCollision;
    public float Offset = 0;
    public float Delay = 3;


    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
    private ParticleSystem ps;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }
    void OnParticleCollision(GameObject other)
    {

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        int i = 0;
        while (i < numCollisionEvents)
        {
            foreach (var eff in EffectsOnCollision)
            {
                var instance = Instantiate(eff, collisionEvents[i].intersection + collisionEvents[i].velocity * Offset, new Quaternion()) as GameObject;
                instance.transform.LookAt(collisionEvents[i].intersection + collisionEvents[i].normal);
                Destroy(instance, Delay);
            }
            i++;
        }
    }
}
