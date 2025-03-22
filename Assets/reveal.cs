using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reveal : MonoBehaviour
{
    bool IsRevealed = false;

    public float speed;
    public GameObject Hand;
    public GameObject TargetHID;
    public GameObject TargetREV;


    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            IsRevealed = !IsRevealed;
        }

        if(IsRevealed)
        {
            Hand.transform.position = Vector3.MoveTowards(Hand.transform.position, TargetREV.transform.position, speed);
        }
        else
        {
            Hand.transform.position = Vector3.MoveTowards(Hand.transform.position, TargetHID.transform.position, speed);
        }
    }
}
