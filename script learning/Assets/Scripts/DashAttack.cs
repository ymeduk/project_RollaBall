using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnParticleCollision (Collider other)
   {
       //HeartSystem.health -= 1;
          if(other.gameObject.tag == "Hit")
          {
             Destroy(gameObject);
          }
   }

}
