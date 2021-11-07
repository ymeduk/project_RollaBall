using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem collectParticle;
    public AudioSource collectSound;
    public Transform ParticleEnd;



 void OnTriggerEnter(Collider collider)
{
            if (collider.tag == "Player")
    {
         Instantiate(collectSound);
         Instantiate(collectParticle, ParticleEnd.position, ParticleEnd.rotation);
    }
}
}
