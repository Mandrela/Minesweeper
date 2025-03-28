using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class module3button : MonoBehaviour
{
    public Color HighlightColor;
    public TextMeshPro DigitField;

    Color NormalColor;
    Renderer rend;
    module3 ParentScript;
    int Digit = -1;
    public bool isPressed = false;

    void Start() {
        rend = GetComponent<Renderer>();
        NormalColor = rend.material.color;
        HighlightColor.a = 1f;
        ParentScript = GetComponentInParent<module3>();
        UpdateDigitField();
    }

    void UpdateDigitField()
    {
        DigitField.text = "" + Digit;
    }

    void OnMouseEnter()
    {
        if (!isPressed)
        {
            rend.material.color = HighlightColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = NormalColor;
    }

    void OnMouseDown()
    {
        if (!isPressed)
        {
            isPressed = true;
            
            ParentScript.PushDigit(Digit);
            NormalColor = HighlightColor;
            OnMouseExit();
        }
    }
}
