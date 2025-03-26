using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIU : MonoBehaviour
{
    public TextMeshProUGUI textField1;
    public TextMeshProUGUI textField2;
    public TextMeshProUGUI textField3;
    public TextMeshProUGUI textField4;

    public IntValue Stress;
    public IntValue State;
    public IntValue Type;
    public StringValue Answer;

    // Update is called once per frame
    void Update()
    {
        textField1.text = "Stress Level: " + Stress.Value;
        textField2.text = "Stress State: " + State.Value;
        textField4.text = "Stress Type: " + Type.Value;
        textField3.text = "Answer: " + Answer.Value;
    }
}
