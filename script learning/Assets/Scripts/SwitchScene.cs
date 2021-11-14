using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public float TransitionTime = 1f;
    public Animator transition;
    public string LevelName;
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene(LevelName);
    }
}
