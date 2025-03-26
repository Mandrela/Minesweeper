using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class module1 : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] GameEvent ModuleSolvedEvent; // req
    [SerializeField] GameEvent ModuleLostEvent; // req
    [SerializeField] GameEvent ModuleAskedEvent; // req
    [SerializeField] StringSet Guidelines; // req
    public string moduleName = "wires"; // req
    string guideline;

    [Header("Wiring")]
    [SerializeField] List<string> wireColors = new List<string>{"красный", "зеленый", "синий"};
    [SerializeField] ModuleLineTemplates lineTemplates; // req
    string replaceMark = "%mark%"; // req
    public GameObject wireR;
    public GameObject wireG;
    public GameObject wireB;
    public Vector3[] relativePositions;
    Transform[] wires;
    int[] indexes;
    int correctAnswer;
    int incorrectAnswer;

    [Header("Highlight options")]
    public Color HighlightColor;
    public float Alpha = 1f;
    Color NormalColor;
    Renderer rend;

    string ProtoDelimiter = ";";

    // Start is called before the first frame update
    void Start()
    {
        this.wires = new Transform[] {this.wireR.transform, this.wireG.transform, this.wireB.transform};
        this.indexes = Utils.GenerateSequence(3);
        for (int i = 0; i < 3; i++) {
            this.wires[this.indexes[i]].localPosition = this.relativePositions[i];
        }

        this.correctAnswer = Utils.Next(3);
        this.incorrectAnswer = Utils.Next(3);
        while (this.incorrectAnswer == this.correctAnswer) {
            this.incorrectAnswer = Utils.Next(3);
        }

        this.rend = GetComponent<Renderer>();
        this.HighlightColor.a = this.Alpha;
        this.NormalColor = this.rend.material.color;

        Debug.Log("Created wire module " + this.gameObject.name + " with correct answer " + this.correctAnswer + " and wrong answer " + this.incorrectAnswer);
    }

    public void CheckSolution(Transform trans) { // warn
        if (this.wires[this.indexes[this.correctAnswer]] == trans) {
            this.ModuleSolvedEvent.Raise();
        } else {
            this.ModuleLostEvent.Raise();
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            this.ModuleAskedEvent.Raise(this.moduleName + this.ProtoDelimiter + // shit thing
                lineTemplates.GetRandomJohn().Replace(this.replaceMark, this.wireColors[this.correctAnswer]) + this.ProtoDelimiter +
                lineTemplates.GetRandomJohn().Replace(this.replaceMark, this.wireColors[this.incorrectAnswer]));
        }
    }

    //Guidelines
    void OnEnable()
    {
        this.guideline = lineTemplates.GetRandomGuide().Replace(this.replaceMark, this.wireColors[this.incorrectAnswer]);
        this.Guidelines.AddNonUnique(this.guideline);
    }

    void OnDisable()
    {
        this.Guidelines.Remove(this.guideline);
    }

    // Highlight
    void OnMouseEnter() 
    {
        this.rend.material.color = this.HighlightColor;
    }

    void OnMouseExit()
    {
        this.rend.material.color = this.NormalColor;
    }
}
