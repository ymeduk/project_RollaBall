using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
   public float force = 1;

   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.tag == "Enemy")
       {
           Vector3 pushDirection = other.transform.position - transform.position;
           pushDirection =- pushDirection.normalized;
           GetComponent<Rigidbody>().AddForce(pushDirection * force * 100);
       }
   }
}
