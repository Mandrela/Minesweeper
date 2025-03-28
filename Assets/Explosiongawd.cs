using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosiongawd : MonoBehaviour
{
    public GameObject boom;
    public AudioSource booms;
    public void DoBOOm()
    {
        booms.Play();
        StartCoroutine(ENdGame());
    }

    IEnumerator ENdGame()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(boom, new Vector3(-6f, 2f, 0f), Quaternion.identity);
        Instantiate(boom, new Vector3(3f, -1f, 0f), Quaternion.identity);
        Instantiate(boom, new Vector3(-5f, -2f, 0f), Quaternion.identity);
        Instantiate(boom, new Vector3(4f, 1.5f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
