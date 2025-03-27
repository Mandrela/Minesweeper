using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public UnityEngine.UI.Image Filler;
    public IntReference FillAmount;
    public float MinOffset;
    public float MaxOffset;
    public float MaxValue;

    Vector2 newValue;

    void FixedUpdate()
    {
        if (FillAmount.Value < MinOffset)
        {
            newValue = new Vector2(0f, 1f);
        }
        else if (FillAmount.Value > MaxValue - MaxOffset)
        {
            newValue = new Vector2(1f, 1f);
        }
        else
        {
            newValue = new Vector2((float) (FillAmount.Value - MinOffset) / (MaxValue - MaxOffset - MinOffset), 1f);
        }
        Filler.transform.localScale = newValue;
    }
}
