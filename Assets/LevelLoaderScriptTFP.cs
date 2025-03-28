using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScriptTFP : MonoBehaviour
{
    public Animator transition;
    private void Start()
    {
        Invoke("LoadNextLevel", 5);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(0));
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