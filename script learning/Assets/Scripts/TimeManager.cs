﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
