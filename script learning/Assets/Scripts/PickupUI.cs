using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUI : MonoBehaviour
{
    public GameObject icon;
	
    void OnEnable()
    {
        icon.SetActive(false);
    }

    void OnDisable()
    {
        icon.SetActive(true);
    }
}
