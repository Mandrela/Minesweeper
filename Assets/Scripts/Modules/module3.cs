using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class module3 : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] GameEvent ModuleSolvedEvent; // req
    [SerializeField] GameEvent ModuleLostEvent; // req
    [SerializeField] GameEvent ModuleAskedEvent; // req
    [SerializeField] StringSet Guidelines; // req
    public string moduleName = "wires"; // req
    string guideline;
    string replaceMark = "%mark%"; // req
    string ProtoDelimiter = ";";

    public ModuleLineTemplates lineTemplates;
    public int[] correctAnswer;
    public int[] incorrectAnswer;
    int curretca = 0;
    public bool IsSolved = false;

    [Header("MAMA")]
    public List<GameObject> Buttons = new List<GameObject>();
    public GameObject StatusShitRed;
    public GameObject StatusShitGreen;
    public Color HighlightColor;
    Color NormalColor;

    void Start()
    {
        int[] array = Utils.GenerateSequence(10);
        correctAnswer = new int[] { array[0], array[1], array[2] };
        incorrectAnswer = (int[]) correctAnswer.Clone();
        incorrectAnswer[Utils.Next(3)] = array[3];

        int[] indexes = Utils.GenerateSequence(4);
        for (int i = 0; i < 4; i++)
        {
            Buttons[indexes[i]].GetComponent<module3button>().UpdateDigitField(array[i]);
        }

        StatusShitRed.GetComponent<Renderer>().enabled = true;
        StatusShitGreen.GetComponent<Renderer>().enabled = false;
        this.NormalColor = GetComponent<Renderer>().material.color;
    }

    public void PushDigit(int SiblingDigit)
    {
        //Debug.Log("Pachimu: " + SiblingDigit);
        if (SiblingDigit == correctAnswer[curretca])
        {
            if (++curretca >= 3)
            {
                ModuleSolvedEvent.Raise();
                StatusShitGreen.GetComponent<Renderer>().enabled = true;
                StatusShitRed.GetComponent<Renderer>().enabled = false;
                IsSolved = true;
            }
        } else {
            ModuleLostEvent.Raise();
            IsSolved = true;
        }
        /*
        if (curretca >= 3 || correctAnswer[curretca] != SiblingDigit)
        {
            ModuleLostEvent.Raise();
        }
        if (curretca >= 3 && correctAnswer[curretca++] == SiblingDigit )
        {
            ModuleSolvedEvent.Raise();
            StatusShitGreen.GetComponent<Renderer>().enabled = true;
            StatusShitRed.GetComponent<Renderer>().enabled = false;
            IsSolved = true;
        }*/
    }

    void OnMouseOver()
    {
        if (!IsSolved && Input.GetMouseButtonDown(1))
        {
            this.ModuleAskedEvent.Raise(this.moduleName + this.ProtoDelimiter + // shit thing
                lineTemplates.GetRandom().Replace(this.replaceMark, "" + correctAnswer[0] + correctAnswer[1] + correctAnswer[2]) + this.ProtoDelimiter +
                lineTemplates.GetRandom().Replace(this.replaceMark, "" + incorrectAnswer[0] + incorrectAnswer[1] + incorrectAnswer[2]));
        }
    }

    //Guidelines
    void OnEnable()
    {
        StartCoroutine(AwaitFor());
    }

    IEnumerator AwaitFor() // kostiiiiiiiiiiiiiiiiiiiiiiiiiil
    {
        yield return new WaitForSeconds(1);
        this.guideline = lineTemplates.GetRandom().Replace(this.replaceMark, "" + incorrectAnswer[0] + incorrectAnswer[1] + incorrectAnswer[2]);
        this.Guidelines.AddNonUnique(this.guideline);
    }

    void OnDisable()
    {
        this.Guidelines.Remove(this.guideline);
    }


    // Highlight
    void OnMouseEnter() 
    {
        if (!IsSolved) {
            GetComponent<Renderer>().material.color = this.HighlightColor;
            StatusShitRed.GetComponent<Renderer>().material.color = this.HighlightColor;
            StatusShitGreen.GetComponent<Renderer>().material.color = this.HighlightColor;
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = this.NormalColor;
        StatusShitGreen.GetComponent<Renderer>().material.color = this.NormalColor;
        StatusShitRed.GetComponent<Renderer>().material.color = this.NormalColor;
    }
}
