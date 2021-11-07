using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimeManager1 : MonoBehaviour
{
    [SerializeField]
    private float DelayBeforeLoading = 10f;
    [SerializeField]
    private float TimeElapsed;

    private void Update()
    {
        TimeElapsed += Time.deltaTime;

        if (TimeElapsed > DelayBeforeLoading)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
