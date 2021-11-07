using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ParticlePlayer : MonoBehaviour
{
public ParticleSystem jumpParticle;
public ParticleSystem WalkParticle;
public ParticleSystem speedParticle;

public AudioSource jumpSound;
public AudioSource DashSound;

public AudioSource Walk;
 public Transform ParticleEnd;

 void Awake()
 {
     
 }



void OnMove(InputValue movementValue)

        
    {   
        Instantiate(Walk);
        Instantiate(WalkParticle, ParticleEnd.position, ParticleEnd.rotation);
    }
void FixedUpdate()

{
    if(Input.GetKeyDown(KeyCode.JoystickButton1))
    {

    //Instantiate(jumpSound);
    Instantiate(jumpParticle, ParticleEnd.position, ParticleEnd.rotation);
    }


    if(Input.GetKeyDown(KeyCode.JoystickButton2))
    {

    Instantiate(DashSound);
    Instantiate(speedParticle);
    }

}


}
