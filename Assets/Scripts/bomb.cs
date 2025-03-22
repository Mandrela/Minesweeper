using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public const int modulesAmount = 6;
    public GameObject[] modules = new GameObject[modulesAmount];
    public Vector2[] modulesPositions = new Vector2[modulesAmount];

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Transform child = this.transform.GetChild(random.Next(3)).gameObject.transform;
        child.GetChild(0).GetComponent<Renderer>().enabled = true;
        child.GetChild(1).GetComponent<Renderer>().enabled = true;

        int[] indexes = GenerateSequence(modulesAmount);
        for (int i = 0; i < modulesAmount; i++) {
            Instantiate(modules[indexes[i]], modulesPositions[i], Quaternion.identity);
        }

        Debug.Log("Bomb created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int[] GenerateSequence(int length) {
        int[] array = new int[length];
        for (int i = 0; i < length; i++) {
            bool flag = true;
            while (flag) {
                array[i] = random.Next(length);
                flag = false;
                for (int j = 0; j < i; j++) {
                    if (array[j] == array[i]) {
                        flag = true;
                        break;
                    }
                }
            }
        }
        return array;
    }
}
