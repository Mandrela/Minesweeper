using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public const int modulesAmount = 6;
    public GameObject[] modules = new GameObject[modulesAmount];
    public Vector2[] modulesPositions = new Vector2[modulesAmount];

    // Start is called before the first frame update
    void Start()
    {
        Transform child = this.transform.GetChild(Utils.Next(3)).gameObject.transform;
        child.GetChild(0).GetComponent<Renderer>().enabled = true;
        child.GetChild(1).GetComponent<Renderer>().enabled = true;

        int[] indexes = Utils.GenerateSequence(modulesAmount);
        for (int i = 0; i < modulesAmount; i++) {
            Instantiate(modules[indexes[i]], modulesPositions[i], Quaternion.identity);
        }

        Debug.Log("Bomb created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
