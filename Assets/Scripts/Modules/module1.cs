using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class module1 : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] GameEvent ModuleSolvedEvent;
    [SerializeField] GameEvent ModuleLostEvent;
    [SerializeField] GameEvent ModuleCreatedEvent;
    [SerializeField] GameEvent ModuleAskedEvent;

    [Header("Wiring")]
    public GameObject wireR;
    public GameObject wireG;
    public GameObject wireB;
    public Vector2[] relativePositions;
    Transform[] wires;
    int[] indexes;
    int correctAnswer;
    int incorrectAnswer;

    [Header("Highlight options")]
    public Color HighlightColor;
    public float Alpha = 1f;
    Color NormalColor;
    Renderer rend;
    
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
        this.ModuleCreatedEvent.Raise();
    }

    public void CheckSolution(Transform trans) {    // Boom output
        if (this.wires[this.indexes[this.correctAnswer]] == trans) {
            this.ModuleSolvedEvent.Raise();
        } else {
            this.ModuleLostEvent.Raise();
        }
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            this.ModuleAskedEvent.Raise();
            Debug.Log("FUCK");
        }
    }

    // Highlight
    void OnMouseEnter() {
        this.rend.material.color = this.HighlightColor;
    }

    void OnMouseExit() {
        this.rend.material.color = this.NormalColor;
    }
}
