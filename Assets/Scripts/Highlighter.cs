using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public Color HighlightColor;
    public float Alpha = 1f;
    private Color NormalColor;
    Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
        HighlightColor.a = Alpha;
        NormalColor = rend.material.color;
    }

    void OnMouseEnter() {
        rend.material.color = HighlightColor;
    }

    void OnMouseExit() {
        rend.material.color = NormalColor;
    }
}
