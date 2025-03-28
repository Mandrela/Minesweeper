using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reveal : MonoBehaviour
{
    bool IsRevealed = false;
    bool IsCompletedMovement = true;
    
    public float speed;
    public GameObject Hand;
    public GameObject TargetHID;
    public GameObject TargetREV;
    GuideManager script;

    public GameObject Timerr;
    public float SpeedUpCoeff = 5f;
    Timer timerScript;

    void Start() {
        script = GetComponent<GuideManager>();
        timerScript = Timerr.GetComponent<Timer>();
    }

    public void ToggleMe()
    {
        if (IsCompletedMovement)
        {
            IsRevealed = !IsRevealed;
            if (!IsRevealed)
                timerScript.DecreaseSpeed(SpeedUpCoeff);
            else
                script.UpdateBook();
            IsCompletedMovement = false;
        }
    }

    void Update()
    {
        if (!IsCompletedMovement)
        {    
            Vector3 newPosition = Vector3.MoveTowards(Hand.transform.position, (IsRevealed ? TargetREV : TargetHID).transform.position, speed);
            if (newPosition == Hand.transform.position) {
                IsCompletedMovement = true;
                if (IsRevealed)
                    timerScript.IncreaseSpeed(SpeedUpCoeff);
            }
            Hand.transform.position = newPosition;
        }
    }
}
