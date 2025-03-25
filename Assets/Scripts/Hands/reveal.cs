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

    void Start() {
        script = GetComponent<GuideManager>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1) && IsCompletedMovement)
        {
            IsRevealed = !IsRevealed;
            IsCompletedMovement = false;
        }

        if (!IsCompletedMovement)
        {    
            Vector3 newPosition = Vector3.MoveTowards(Hand.transform.position, (IsRevealed ? TargetREV : TargetHID).transform.position, speed);
            if (newPosition == Hand.transform.position) {
                IsCompletedMovement = true;
                if (IsRevealed)
                    script.UpdateBook();
            }
            Hand.transform.position = newPosition;
        }
    }
}
