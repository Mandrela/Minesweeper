using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Light_button : MonoBehaviour
{
    public Color HighlightColor;
    public float Alpha = 1f;
    public Animator animatorius;
    
    Color NormalColor;
    Renderer rend;
    module2 ParentScript;
    void Start()
    {
        rend = GetComponent<Renderer>();
        HighlightColor.a = Alpha;
        NormalColor = rend.material.color;
        ParentScript = GetComponentInParent<module2>();
    }

    void OnMouseEnter()
    {
        rend.material.color = HighlightColor;
    }

    void OnMouseExit()
    {
        rend.material.color = NormalColor;
        animatorius.SetBool("IsPressed", false);
    }

    void OnMouseDown()
    {
        animatorius.SetBool("IsPressed", true);
    }

    private void OnMouseUp()
    {
        animatorius.SetBool("IsPressed", false);
    }
}
