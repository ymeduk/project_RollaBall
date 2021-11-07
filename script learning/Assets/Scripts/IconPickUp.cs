using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconPickUp : MonoBehaviour
{
    public GameObject[] pickups;
    public GameObject[] icons;
    
    void Start ()
    {
        if(pickups.Length != icons.Length)
        {
            Debug.LogError("Pickups and icons list must have the same number of items");

        }
    }

    void Update()

    {
        for (int index = 0; index < icons.Length; index++)
        {
            GameObject pickup = pickups[index];
            GameObject icon = icons[index];

            icon.SetActive(pickup.activeSelf);
        }

            
        

    }
    

  
}
