using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class module1 : MonoBehaviour
{
    public Transform wireR;
    public Transform wireG;
    public Transform wireB;
    public Vector2[] relativePositions;

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Transform[] wires = {wireR, wireG, wireB};
        int[] indexes = GenerateSequence(3);
        for (int i = 0; i < 3; i++) {
            wires[indexes[i]].localPosition = relativePositions[i];
        }

        int correctAnswer = random.Next(3);
        int incorrectAnswer = random.Next(3);
        while (incorrectAnswer == correctAnswer) {
            incorrectAnswer = random.Next(3);
        }

        Debug.Log("Created wire module with correct answer " + correctAnswer + " and wrong answer " + incorrectAnswer);
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
