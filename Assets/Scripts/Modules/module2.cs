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
    private int needed_color;
    private int very_wrong_color;
    public Animator animatorik_LIGHT;
    public Animator animatorik_BUTTON;

    [SerializeField] ModuleLineTemplates lineTemplates; 
    string replaceMark = "%mark%";

    [Header("Highlight options")]
    public Color HighlightColor;
    public float Alpha = 1f;
    Color NormalColor;
    Renderer rend;

    bool fl = true;

    void Start()
    {
        needed_color = Utils.Next(3);
        very_wrong_color = Utils.Next(3);
        while (very_wrong_color == needed_color)
        {
            very_wrong_color = Utils.Next(3);
        }
        this.rend = GetComponent<Renderer>();
        this.HighlightColor.a = this.Alpha;
        this.NormalColor = this.rend.material.color;
        StartCoroutine(Timer());
    }

    void FixedUpdateWAIT()
    {
        animatorik_LIGHT.SetInteger("Color_ID", Utils.Next(3));
    }

    private void Update()
    {
        if(animatorik_BUTTON.GetBool("IsPressed")&&(animatorik_LIGHT.GetInteger("Color_ID") == needed_color))
        {
            ModuleSolvedEvent.Raise();
            fl = false;
            Debug.Log("Lights were defused");
        }
        else if(animatorik_BUTTON.GetBool("IsPressed") && (animatorik_LIGHT.GetInteger("Color_ID") != needed_color))
        {
            ModuleLostEvent.Raise();
        }
    }

    void OnMouseEnter()
    {
        this.rend.material.color = this.HighlightColor;
    }
    void OnMouseExit()
    {
        this.rend.material.color = this.NormalColor;
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            FixedUpdateWAIT();
        }
    }
}
