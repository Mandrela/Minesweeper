using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameEvent EventToRaise;
    public bool IsTimerEnabled = false;
    public int TimeIntervalInSeconds = 5;

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

    IEnumerator TimerLoop ()
    {
        while (IsTimerEnabled)
        {
            yield return new WaitForSeconds(TimeIntervalInSeconds);
            EventToRaise.Raise();
        }
    }
}
