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
    Arrow leftArrowScript;
    Arrow rightArrowScript;

    [Header("Content")]
    [SerializeField] GuideLineTemplates guideTempl;
    [SerializeField] StringSet contentStrings;
    [SerializeField] List<string> content = new List<string>();
    [SerializeField] List<string> pages = new List<string>();
    [SerializeField] TextMeshPro textField1;
    [SerializeField] TextMeshPro textField2;
    int count = 0;
    int currentPageNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.leftArrowScript = this.LeftArrow.GetComponent<Arrow>();
        this.rightArrowScript = this.RightArrow.GetComponent<Arrow>();
    }

    void OnEnable() {
        UpdatePagesList();
    }

    public void UpdatePagesList() {
        this.count = contentStrings.GetCount();
        this.currentPageNumber = Mathf.RoundToInt(this.count * Random.value);
        this.content = contentStrings.GetCopy();
        this.UpdateArrows();
        this.UpdateCurrentPage();
    }

    void UpdateArrows() {
        Debug.Log("Update Arrows: " + this.currentPageNumber + ", " + this.count);
        if (this.currentPageNumber == 0)
            this.leftArrowScript.Disable();
        else
            this.leftArrowScript.Enable();
        if (this.count - this.currentPageNumber <= 1)
            this.rightArrowScript.Disable();
        else
            this.rightArrowScript.Enable();
    }

    public void ChangeText(bool isToRight) {
        this.currentPageNumber += isToRight ? 1 : -1;
        this.UpdateArrows();
        this.UpdateCurrentPage();
    }

    public void UpdateCurrentPage() {
        this.textField1.text = this.content[this.currentPageNumber];
        this.textField2.text = this.guideTempl.GetRandomFiller();
    }
}
