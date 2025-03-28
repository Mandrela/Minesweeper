using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarachunManager : MonoBehaviour
{
    public GameEvent GameWon;
    [Header("Variables")]
    public StringReference AnswerText;
    public IntReference StressState;
    public IntReference StressType;
    public IntReference StressLevel;

    [Header("Preferences")]
    public int InitialStressLevel = 20;
    [Space]
    public int ModuleSolvedStressDecrementValue = 15;
    public int ModuleAskStressIncrementValue = 5;
    public int TimerStressIncrementValue = 1;
    public int DuckValue = 50;
    [Space]
    public int SuccessfulSedation = 25;
    public int AbortiveSedation = 25;
    [Space]
    public List<int> StateThresholds = new List<int> {0, 5, 25, 60, 80, 95, 100};

    string ProtoDelimiter = ";";
    string replaceMark = "%mark%";
    bool fl = true;

    public int modulesToSolveCount = 3;
    public int modulesSolved = 0;

    [Header("Data files")]
    public ModuleLineTemplates DimlyLines;
    public ModuleLineTemplates HoofLines;
    public ModuleLineTemplates FuckYou;
    public ModuleLineTemplates TotallyTrue;
    [Space()]
    public ModuleLineTemplates FearLines;
    public ModuleLineTemplates DespairLines;
    public ModuleLineTemplates PanicLines;
    public ModuleLineTemplates NormalLines;
    [Space()]
    public ModuleLineTemplates SuccessLines;

    List<ModuleLineTemplates> Liners = new List<ModuleLineTemplates>();

    void OnEnable()
    {
        Liners.Add(FearLines);
        Liners.Add(DespairLines);
        Liners.Add(PanicLines);
        Liners.Add(NormalLines);
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
        this.modulesSolved++;
        DecreaseStress(this.ModuleSolvedStressDecrementValue);
        if (this.modulesSolved >= this.modulesToSolveCount)
        {
            this.fl = false;
            this.StressState.Value = 0;
            this.AnswerText.Value = "Ты решил их все, ты огромный молодец!!! Я горжусь твоим пальцем";
            GameWon.Raise();
        }
        else 
        {
            this.AnswerText.Value = SuccessLines.GetRandom().Replace(this.replaceMark, "" +  (this.modulesToSolveCount - this.modulesSolved));
        }
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
            this.AnswerText.Value = DimlyLines.GetRandom();
        }
        else if (typeOfStress == this.StressType.Value)
        {
            DecreaseStress(this.SuccessfulSedation);
            this.AnswerText.Value = HoofLines.GetRandom(); 
        }
        else
        {
            IncreaseStress(this.AbortiveSedation);
            this.AnswerText.Value = FuckYou.GetRandom(); 
        }
    }

    public void ModuleAsked(string message)
    {
        if (this.fl)
        {
            this.fl = false;
            ModuleAnswer modu1e = new ModuleAnswer(message, this.ProtoDelimiter);
            switch (StressState.Value)
            {
                case 0:
                {
                    this.AnswerText.Value = TotallyTrue.GetRandom().Replace(this.replaceMark, modu1e.CorrectMove);
                    break;
                }
                case 5:
                {
                    this.AnswerText.Value = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
                    break;
                }
                default:
                {
                    if (Utils.Next(100) > this.StressLevel.Value)
                    {
                        this.AnswerText.Value = this.Liners[this.StressState.Value >= 2 ? this.StressType.Value : 3].
                            GetRandom().Replace(this.replaceMark, modu1e.CorrectMove);
                    }
                    else
                    {
                        this.AnswerText.Value = this.Liners[this.StressState.Value >= 2 ? this.StressType.Value : 3].
                            GetRandom().Replace(this.replaceMark, modu1e.WrongMove);
                    }
                    break;
                }
            }
            IncreaseStress(this.ModuleAskStressIncrementValue);
        }
    }

    public void SetFlag()
    {
        this.fl = true;
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