using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarachunManager : MonoBehaviour
{
    [Header("Variables")]
    public StringReference AnswerText;    
    public IntReference StressState;
    public FloatReference StressLevel;
    public float InitialStressLevel;
    public int ModuleSolvedStressDecrementValue = 15;
    public int TimerStressIncrementValue = 15;

    [Header("Status")]
    public List<int> StateThresholds = new List<int> {5, 25, 60, 80, 95};

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
        if ((StressState.Value < StateThresholds.Count - 1 && StressLevel.Value >= StateThresholds[StressState.Value + 1])
            || StressLevel.Value < StateThresholds[StressState.Value])
        {
            int i = 0;
            while (StressLevel.Value >= StateThresholds[i++] && i < StateThresholds.Count) {}
            StressState.Value = --i;
        }

    }

    public void ModuleSolved()
    {
        DecreaseStress(this.ModuleSolvedStressDecrementValue);
        AnswerText.Value = "You solved something!... Probably..."; // future mark
    }

    public void TimerTrigger()
    {
        IncreaseStress(this.TimerStressIncrementValue);
    }
}
