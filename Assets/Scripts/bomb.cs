using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Transform child = this.transform.GetChild(random.Next(3)).gameObject.transform;
        child.GetChild(0).GetComponent<Renderer>().enabled = true;
        child.GetChild(1).GetComponent<Renderer>().enabled = true;
        Debug.Log("Bomb created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
