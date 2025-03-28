using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript3 : MonoBehaviour
{
    public GameObject thingy;
    public Animator transition;
    private void Start()
    {
        Invoke("LoadNextLevel", 54);
        Invoke("ThisIsYou", 3);
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

    public void ThisIsYou()
    {
        thingy.SetActive(false);
    }
}