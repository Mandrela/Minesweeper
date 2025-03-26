using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class module2 : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] GameEvent ModuleSolvedEvent; 
    [SerializeField] GameEvent ModuleLostEvent; 
    [SerializeField] GameEvent ModuleAskedEvent;
    [SerializeField] StringSet Guidelines;
    public string moduleName = "lights"; 
    string guideline;

    [SerializeField] ModuleLineTemplates lineTemplates; 
    string replaceMark = "%mark%";

    [Header("Highlight options")]
    public Color HighlightColor;
    public float Alpha = 1f;
    Color NormalColor;
    Renderer rend;

    void Start()
    {
        this.rend = GetComponent<Renderer>();
        this.HighlightColor.a = this.Alpha;
        this.NormalColor = this.rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        this.rend.material.color = this.HighlightColor;
    }
    void OnMouseExit()
    {
        this.rend.material.color = this.NormalColor;
    }
}
