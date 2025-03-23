using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class module1 : MonoBehaviour
{
    public Transform wireR;
    public Transform wireG;
    public Transform wireB;
    public Vector2[] relativePositions;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] wires = {wireR, wireG, wireB};
        int[] indexes = Utils.GenerateSequence(3);
        for (int i = 0; i < 3; i++) {
            wires[indexes[i]].localPosition = relativePositions[i];
        }

        int correctAnswer = Utils.Next(3);
        int incorrectAnswer = Utils.Next(3);
        while (incorrectAnswer == correctAnswer) {
            incorrectAnswer = Utils.Next(3);
        }

        Debug.Log("Created wire module with correct answer " + correctAnswer + " and wrong answer " + incorrectAnswer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
