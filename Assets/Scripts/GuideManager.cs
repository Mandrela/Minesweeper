using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuideManager : MonoBehaviour
{
    [Header("Arrows")]
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public Color NormalColor;
    public Color HighlightColor;
    public Color DisableColor;
    public Material Cock;
    Arrow leftArrowScript;
    Arrow rightArrowScript;

    [Header("Content")]
    [SerializeField, Range(1, 5)] int GarbageMultiplier = 3;
    [SerializeField] GuideLineTemplates guideTemplates;
    [SerializeField] StringSet contentStrings;
    [SerializeField] List<Spread> Book = new List<Spread>();
    int currentSpreadNumber = 0;

    [Header("Output")]
    [SerializeField] TextMeshPro textField1;
    [SerializeField] TextMeshPro textField2;    

    // Start is called before the first frame update
    void Start()
    {
        this.leftArrowScript = this.LeftArrow.GetComponent<Arrow>();
        this.rightArrowScript = this.RightArrow.GetComponent<Arrow>();
    }

    void OnEnable() {
        UpdateBook();
    }

    public void UpdateBook() {
        Debug.Log("Book is being updated");
        if (this.Book.Count == 0 ||
                this.contentStrings.GetCount() * this.GarbageMultiplier != this.Book.Count * 2 - this.Book[this.Book.Count - 1].GetEmptyPageCount()) {
            GenerateNewBook(this.contentStrings.GetCount());
        }
        this.currentSpreadNumber = Utils.Next(this.Book.Count);
        ShowCurrentSpread();
    }

    void GenerateNewBook(int ContentAmount) {
        Debug.Log("Generating new Book");
        List<Spread> newBook = new List<Spread>();
        for (int i = 0; i < ContentAmount * this.GarbageMultiplier; i += 2) {
            newBook.Add(new Spread());
        }
        int[] pageNumbers = Utils.GenerateSequence(ContentAmount * this.GarbageMultiplier);
        
        for (int i = 0; i < ContentAmount; i++) {
            newBook[pageNumbers[i] / 2].SetPage(pageNumbers[i] % 2 == 1, guideTemplates.GetRandomTemplate().Replace("%mark%", this.contentStrings.GetItem(i)));
        }
        
        for (int i = ContentAmount; i < ContentAmount * this.GarbageMultiplier; i++) {
            newBook[pageNumbers[i] / 2].SetPage(pageNumbers[i] % 2 == 1, guideTemplates.GetRandomFiller());
        }
        this.Book = newBook;
    }

    public void ChangeCurrentSpreadNum(bool IsToRight=false) {
        this.currentSpreadNumber += IsToRight ? 1 : -1;
        this.ShowCurrentSpread();
    }

    void ShowCurrentSpread() {
        this.textField1.text = this.Book[this.currentSpreadNumber].GetLeftPage();
        this.textField2.text = this.Book[this.currentSpreadNumber].GetRightPage();
        UpdateArrows();
    }

    void UpdateArrows() {
        Debug.Log("Update Arrows: " + this.currentSpreadNumber + ", " + this.Book.Count);
        if (this.currentSpreadNumber == 0)
            this.leftArrowScript.Disable();
        else
            this.leftArrowScript.Enable();
        if (this.Book.Count - this.currentSpreadNumber <= 1)
            this.rightArrowScript.Disable();
        else
            this.rightArrowScript.Enable();
    }
}


class Spread {
    string leftPage;
    string rightPage;

    public Spread(string leftPagew="", string rightPagew="") {
        this.leftPage = leftPagew;
        this.rightPage = rightPagew;
    }

    public string GetLeftPage() {
        return this.leftPage;
    }

    public string GetRightPage() {
        return this.rightPage;
    }

    public void SetPage(bool IsRight=false, string s="") {
        if (IsRight)
            this.rightPage = s;
        else
            this.leftPage = s;
    }

    public int GetEmptyPageCount() {
        int val = 0;
        if (this.leftPage == "") {
            val++;
        }
        if (this.rightPage == "") {
            val++;
        }
        return val;
    }
}
