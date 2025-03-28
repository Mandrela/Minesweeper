using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshPro Display;
    public GameEvent EventToRaise;
    public GameEvent GameLost;
    public bool IsTimerEnabled = false;
    public float TimeIntervalInSeconds = 1;

    float TimeLast = 420;

    void OnEnable() {
        Debug.Log("Timer started");
        StartTimer();
    }

    public void StartTimer()
    {
        if (!IsTimerEnabled)
        {
            IsTimerEnabled = true;
            StartCoroutine(TimerLoop());
        }
    }

    public void EndTimer()
    {
        IsTimerEnabled = false;
    }

    void DisplayDisplay()
    {
        Display.text = "" + (int) TimeLast / 60 + ":" +
            ((int) TimeLast % 60 >= 10 ? "" : "0") + (int) TimeLast % 60;
    }

    IEnumerator TimerLoop ()
    {
        DisplayDisplay();
        while (IsTimerEnabled)
        {
            yield return new WaitForSecondsRealtime(TimeIntervalInSeconds);
            TimeLast -= 1;
            DisplayDisplay();

            EventToRaise.Raise();
            if (TimeLast <= 0f)
            {
                for (int i = 0; i < 7; i++)
                {
                    yield return new WaitForSeconds(0.5f);
                    Display.enabled = !Display.enabled;
                }
                GameLost.Raise();
                break;
            }
        }
    }

    public void IncreaseSpeed(float factor)
    {
        this.TimeIntervalInSeconds /= factor;   
    }

    public void DecreaseSpeed(float factor)
    {
        this.IncreaseSpeed(1 / factor);
    }
}
