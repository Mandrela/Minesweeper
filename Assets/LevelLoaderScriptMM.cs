using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScriptMM : MonoBehaviour
{
    public Animator transition;
    public Animator animator;
    void Update()
    {
        if (animator.GetBool("end"))
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        //play anima
        transition.SetTrigger("start");
        //wait
        yield return new WaitForSeconds(2);
        //load da scene
        SceneManager.LoadScene(LevelIndex);
    }
}