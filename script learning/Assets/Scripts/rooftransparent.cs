using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class rooftransparent : MonoBehaviour
{
    #region public
    [Header("What should be shown")]
    public GameObject OjbetToShow;
 
    [Header("Params")]
    public float ShowAtDistance = 10f;
    public float checkEachSec   = 2f;
    public Transform TargetTrans;
    #endregion
 
    #region private
    private Transform localTrans;
    private bool checkingActive = true;
    #endregion
 
 
    void Start()
    {
        if (TargetTrans == null)
        {
            GameObject pl = GameObject.FindGameObjectWithTag("Player");
            if(pl != null)
                TargetTrans = pl.transform;
        }
 
        //Caching for performance..
        localTrans = this.transform;
 
        StartCoroutine(WaitForNextFrame());
    }
 
    IEnumerator WaitForNextFrame()
    {
        yield return null;
        while (checkingActive)
        {
            yield return new WaitForSeconds(checkEachSec);
 
            if (TargetTrans && localTrans)
            {
                float dist = Vector3.Distance(localTrans.position, TargetTrans.position);
 
                Debug.Log("Distance to Player: " + dist);
 
                if (OjbetToShow) OjbetToShow.SetActive(dist > ShowAtDistance);
            }
        }
    }
 
}