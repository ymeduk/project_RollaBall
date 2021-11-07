using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoins : MonoBehaviour
{
    public AudioSource collectSound;
       void OnTriggerEnter(Collider other)
    {
        
            collectSound.Play();
            CollectibleCoin.coins += 1;
            Destroy(gameObject);        
    }
}
