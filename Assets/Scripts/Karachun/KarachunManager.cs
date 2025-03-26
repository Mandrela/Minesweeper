using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarachunManager : MonoBehaviour
{
    [Header("Variables")]
    public StringReference AnswerText;
    public IntReference StressState;
    public IntReference StressType;
    public FloatReference StressLevel;

    [Header("Preferences")]
    public float InitialStressLevel;
    public int ModuleSolvedStressDecrementValue = 15;
    public int TimerStressIncrementValue = 15;
    public int DuckValue = 50;
    public int SuccessfulSedation = 25;
    public int AbortiveSedation = 25;

    [Header("Status")]
    public List<int> StateThresholds = new List<int> {0, 5, 25, 60, 80, 95, 100};

    void OnEnable()
    {
        StressLevel.Value = InitialStressLevel;
        StressState.Value = 0;
        AnswerText.Value = "";
        CheckChangeStatus();
    }

    void DecreaseStress(float value)
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

    void IncreaseStress(float value)
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
}
