using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HandClick : MonoBehaviour
{
    public AudioSource aud;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("IsClickL", Input.GetMouseButton(0));
        animator.SetBool("IsClickR", Input.GetMouseButton(1));
        if(Input.GetMouseButtonDown(0))
        {
            aud.Play();
        }
    }
}
