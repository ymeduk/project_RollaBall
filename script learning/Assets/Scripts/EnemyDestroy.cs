using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
   {
       //HeartSystem.health -= 1;
          if(other.gameObject.tag == "Player")
          {
             Destroy(gameObject);
          }
   }

}
