using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPusher : MonoBehaviour
{
    public GameEvent DialogTry;

    public TextMeshProUGUI FearTextField;
    public ModuleLineTemplates FearLines;
    public TextMeshProUGUI DespairTextField;
    public ModuleLineTemplates DespairLines;
    public TextMeshProUGUI PanicTextField;
    public ModuleLineTemplates PanicLines;

    public Color TextColor;
    public Color AnotherTextColor;

    public float RechargeTime = 3f;

    bool AskDisabled = false;

    void OnEnable()
    {
        StartCoroutine(DelayedUpdateStart(1f));
    }

    IEnumerator DelayedUpdateStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        UpdateFields();
    }

    void UpdateFields()
    {
        FearTextField.text = "1: " + FearLines.GetRandom();
        FearTextField.color = TextColor;
        DespairTextField.text = "2: " + DespairLines.GetRandom();
        DespairTextField.color = TextColor;
        PanicTextField.text = "3: " + PanicLines.GetRandom();
        PanicTextField.color = TextColor;
        AskDisabled = false;
    }

    void LolRaise(string message)
    {
        AskDisabled = true;
        DialogTry.Raise(message);
        StartCoroutine(DelayedUpdateStart(RechargeTime));
    }

    void Update()
    {
        if (!AskDisabled)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FearTextField.color = AnotherTextColor;
                LolRaise("0");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DespairTextField.color = AnotherTextColor;
                LolRaise("1");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PanicTextField.color = AnotherTextColor;
                LolRaise("2");
            }
        }
    }
}
