using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
   Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("start", true);
            Invoke("StartDelay", 3);
        }

        if (animator.GetBool("end"))
        {
            SceneManager.LoadScene(1);
        }
    }

    void StartDelay()
    {
        animator.SetBool("end", true);
    }
}
