using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    Animator animator;
    public AudioSource door;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
  /*
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("start", true);
            animator.SetBool("end", true);
        }
    }
  */
    private void OnMouseDown()
    {
        door.Play();
        animator.SetBool("start", true);
        animator.SetBool("end", true);
    }
}
