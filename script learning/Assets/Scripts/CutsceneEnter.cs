using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutsceneCam;


    void Start()
    
    
    {
        cutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        Debug.Log("HELLOOOOOO IS THIS WORKING");
        StartCoroutine(FinishCut());
    } 

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(5);
        thePlayer.SetActive(true);
        cutsceneCam.SetActive(false);
        
    }
    
}
