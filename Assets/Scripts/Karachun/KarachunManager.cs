using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarachunManager : MonoBehaviour
{
    [Header("Variables")]
    public StringReference AnswerText;
    public IntReference StressState;
    public IntReference StressType;
    public IntReference StressLevel;

    [Header("Preferences")]
    public int InitialStressLevel = 20;
    [Space]
    public int ModuleSolvedStressDecrementValue = 15;
    public int TimerStressIncrementValue = 15;
    public int DuckValue = 50;
    [Space]
    public int SuccessfulSedation = 25;
    public int AbortiveSedation = 25;
    [Space]
    public List<int> StateThresholds = new List<int> {0, 5, 25, 60, 80, 95, 100};

    string ProtoDelimiter = ";";

    void OnEnable()
    {
        StressLevel.Value = InitialStressLevel;
        StressState.Value = 0;
        AnswerText.Value = "";
        CheckChangeStatus();
    }

    void DecreaseStress(int value)
    {
        if (StressLevel.Value < value)
        {
            StressLevel.Value = 0;
        } else
        {
            StressLevel.Value -= value;
        }
        CheckChangeStatus();
    }

    void IncreaseStress(int value)
    {
        if (StressLevel.Value + value > 100)
        {
            StressLevel.Value = 100;
        } else
        {
            StressLevel.Value += value;
        }
        CheckChangeStatus();
    }

    void CheckChangeStatus()
    {
        if (StressLevel.Value <= StateThresholds[StressState.Value] || StressLevel.Value > StateThresholds[StressState.Value])
        {
            int previousState = StressState.Value;
            int i = 0;
            while (StressLevel.Value > StateThresholds[i + 1]) { i++; }
            StressState.Value = i;
            if ((i > previousState && i > 1 && previousState <= 1) || i < previousState) // warn: hardcode
            {
                StressType.Value = Utils.Next(3);
            }
        }
    }

    public void ModuleSolved()
    {
        DecreaseStress(this.ModuleSolvedStressDecrementValue);
        this.AnswerText.Value = "You solved something!... Probably..."; // future mark
    }

    public void TimerTrigger()
    {
        IncreaseStress(this.TimerStressIncrementValue);
    }

    public void Duck()
    {
        DecreaseStress(this.DuckValue);
    }

    public void Dialog(string typeOfStressStr)
    {
        int typeOfStress;
        if (!System.Int32.TryParse(typeOfStressStr, out typeOfStress))
        {
            return;
        }

        if (this.StressState.Value <= 1)
        {
            this.AnswerText.Value = "I don't understand you"; // future mark
        }
        else if (typeOfStress == this.StressType.Value)
        {
            DecreaseStress(this.SuccessfulSedation);
            this.AnswerText.Value = "What a relief"; // future mark
        }
        else
        {
            IncreaseStress(this.AbortiveSedation);
            this.AnswerText.Value = "You made it worse"; // future mark
        }
    }

    public void ModuleAsked(string message)
    {
        ModuleAnswer module = new ModuleAnswer(message, this.ProtoDelimiter);
        this.AnswerText.Value = "Module " + module.Name + " asked me tell you that you should " + module.CorrectMove + " and shouldn't " + module.WrongMove; // future mark
    }
}


class ModuleAnswer
{
    public string Name;
    public string CorrectMove;
    public string WrongMove;

    public ModuleAnswer(string s, string delimiter)
    {
        string[] ss = s.Split(delimiter, 3);
        Name = ss[0];
        CorrectMove = ss[1];
        WrongMove = ss[2];
    } 
}