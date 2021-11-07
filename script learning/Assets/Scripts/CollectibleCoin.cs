using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCoin : MonoBehaviour
{
    public static int coins;
    public TextMeshProUGUI coinText;
    
   
    void update()
    {
        
            coinText.GetComponent<TextMesh>().text ="SCORE" + coins;
    }

}
