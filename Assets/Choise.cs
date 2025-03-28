using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choise : MonoBehaviour
{
    public GameObject other;
    public Animator animator;
    public AudioSource BombChoose;
    public AudioSource MainMusic;
    public AudioSource ChipsChoose;
    private void OnMouseDown()
    {
        if(gameObject.name == "Bomb")
        {
            animator.SetInteger("His_state", 1);
            this.gameObject.SetActive(false);
            other.SetActive(false);
            BombChoose.Play();
            MainMusic.Stop();
            Invoke("NextLEV", 3);
        }
        else if (gameObject.name == "Chipsi")
        {
            animator.SetInteger("His_state", 2);
            this.gameObject.SetActive(false);
            other.SetActive(false);
            ChipsChoose.Play();
            MainMusic.Stop();
            Invoke("ToMM", 4);
        }
    }
    private void ToMM()
    {
        animator.SetInteger("His_state", 4);
    }
    private void NextLEV()
    {
        animator.SetInteger("His_state", 3);
    }
}
