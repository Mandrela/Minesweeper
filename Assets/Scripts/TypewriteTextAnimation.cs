using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode()]
public class TypewriteTextAnimation : MonoBehaviour
{
    public GameEvent TypingStartEvent;
    public GameEvent TypingEndEvent;

    [Header("Animation Settings")]
    public float LetterTypeDelaySeconds = 1f;
    public float Koeffichient = 1;
    public int OneFromValueChance = 1;
    [Header("Utility")]
    public StringReference TextToCopy;
    public TextMeshProUGUI TextField;
    
    Coroutine Loop;
    string TargetText;
    int CurrentTextPosition = 0;
    bool fl = false;

    void OnEnable()
    {
        Loop = StartCoroutine(TypewriterLoop());
    }

    void OnDisable()
    {
        StopCoroutine(Loop);
    } 

    IEnumerator TypewriterLoop()
    {
        while (true) 
        {
            if (TextToCopy.Value != TargetText)
            {
                TargetText = TextToCopy.Value;
                CurrentTextPosition = 0;
                TextField.text = "";
                fl = true;
                TypingStartEvent.Raise();
            }
            else if (CurrentTextPosition < TargetText.Length)
            {
                TextField.text += TargetText[CurrentTextPosition++];
            }
            else if (fl)
            {
                fl = false;
                TypingEndEvent.Raise();
            }
            yield return new WaitForSeconds(LetterTypeDelaySeconds * (Utils.Next(OneFromValueChance) != 0 ? 1 : Koeffichient));
        }
    }
}
