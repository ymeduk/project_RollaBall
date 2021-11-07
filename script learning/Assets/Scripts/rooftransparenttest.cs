using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rooftransparenttest : MonoBehaviour
{
    //public GameObject Item1, Item2, Item3;
    public List<MeshRenderer> ItemsList;

    void OnTriggerEnter(Collider collider)

    {
        if (collider.tag == "Player")
        {
            ToggleItemsVisibility(false);

        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")

        {
           ToggleItemsVisibility(true);


        }
    }



        private void ToggleItemsVisibility(bool ActiveState)
        {
           foreach (MeshRenderer item in ItemsList)
           {
               item.enabled=ActiveState;
           }
        }




    
}
