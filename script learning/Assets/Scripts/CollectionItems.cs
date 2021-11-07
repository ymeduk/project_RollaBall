using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItems : MonoBehaviour
{
   public GameObject Item;

void OnCollisionEnter(Collision col) 
    {
       if (col.gameObject == (false))
       Item.SetActive(true);
   }
}
