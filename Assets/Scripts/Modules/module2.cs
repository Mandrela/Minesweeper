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
    public float HoldDelay = 0.3f;

    [Header("Colors")]
    [SerializeField] ModuleLineTemplates lineTemplates;
    [SerializeField] List<string> colors = new List<string> {"красного", "зеленого", "синего"};
    string replaceMark = "%mark%";
    string ProtoDelimiter = ";";

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
        if (fl && animatorik_BUTTON.GetBool("IsPressed"))
        {
            if(animatorik_LIGHT.GetInteger("Color_ID") == needed_color)
            {
                ModuleSolvedEvent.Raise();
            }
            else
            {
                ModuleLostEvent.Raise();
            }
            fl = false;
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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            this.ModuleAskedEvent.Raise(this.moduleName + this.ProtoDelimiter +
                lineTemplates.GetRandom().Replace(this.replaceMark, this.colors[this.needed_color]) + this.ProtoDelimiter +
                lineTemplates.GetRandom().Replace(this.replaceMark, this.colors[this.very_wrong_color]));
        }
    }

    IEnumerator Timer()
    {
        while (fl)
        {
            yield return new WaitForSeconds(HoldDelay);
            FixedUpdateWAIT();
        }
        animatorik_LIGHT.SetInteger("Color_ID", 3);
    }

    void OnEnable()
    {
        StartCoroutine(AwaitFor());
    }

    IEnumerator AwaitFor() // kostiiiiiiiiiiiiiiiiiiiiiiiiiil
    {
        yield return new WaitForSeconds(1);
        this.guideline = lineTemplates.GetRandom().Replace(this.replaceMark, this.colors[this.very_wrong_color]);
        this.Guidelines.AddNonUnique(this.guideline);
    }

    void OnDisable()
    {
        this.Guidelines.Remove(this.guideline);
    }
}
