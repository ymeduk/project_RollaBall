using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
  public AudioSource ImpactSound;
  public AudioSource BigImpact;
  public ParticleSystem JumpParticle;
public ParticleSystem BigImpactParticle;
public float SmallImpactInf = 15f;
public float BigImpactSup = 15f;



  void OnCollisionEnter(Collision collision)
  {
      if (collision.relativeVelocity.magnitude < SmallImpactInf)
      {
        ImpactSound.Play();
        JumpParticle.Play();
      }
       if (collision.relativeVelocity.magnitude > BigImpactSup)
      {
        BigImpact.Play();
        BigImpactParticle.Play();
      }
  }

}
