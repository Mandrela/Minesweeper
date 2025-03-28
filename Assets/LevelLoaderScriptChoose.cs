using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScriptChoose : MonoBehaviour
{
    public Animator check;
    public Animator transition;

    void Update()
    {
        if(check.GetInteger("His_state") == 4)
        {
            LoadMM();
        }
        else if(check.GetInteger("His_state") == 3)
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadMM()
    {
        StartCoroutine(LoadLevel(1));
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