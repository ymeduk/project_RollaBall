using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   void OnTriggerEnter (Collider other)
   {
       HeartSystem.health -= 1;
          if(other.gameObject.tag == "Player")
          {
              Vector3 damageDirection = other.transform.position = transform.position;
              damageDirection = damageDirection.normalized;
          }

   }

}
