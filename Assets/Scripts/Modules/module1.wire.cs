using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class wire : MonoBehaviour
{
    public Color HighlightColor;
    public float Alpha = 1f;
    public GameObject TornedWire;
    
    bool isCut = false;
    
    Color NormalColor;
    Renderer rend;
    module1 ParentScript;

    void Start() {
        rend = GetComponent<Renderer>();
        HighlightColor.a = Alpha;
        NormalColor = rend.material.color;
        ParentScript = GetComponentInParent<module1>();
    }

    void OnMouseEnter() {
        if (!isCut) {
            rend.material.color = HighlightColor;
        }
    }

    void OnMouseExit() {
        rend.material.color = NormalColor;
    }

    void OnMouseDown() {
        if (!isCut) {
            isCut = true;
            TornedWire.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            
            ParentScript.CheckSolution(transform);
            OnMouseExit();
        }
    }
}
