using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KarachunFace : MonoBehaviour
{
    public Animator FaceAnimator;
    public RuntimeAnimatorController NormalAnimationController;
    public RuntimeAnimatorController FearAnimationController;
    public RuntimeAnimatorController DispairAnimationController;
    public RuntimeAnimatorController PanicAnimationController;

    public IntReference KarachunType;
    public IntReference KarachunState;

    public float delay = 1f;
    public float timeOfAnimation = 10f;
    List<RuntimeAnimatorController> Animators = new List<RuntimeAnimatorController>();

    void OnEnable()
    {
        Animators.Clear();
        Animators.Add(FearAnimationController);
        Animators.Add(DispairAnimationController);
        Animators.Add(PanicAnimationController);
        Animators.Add(NormalAnimationController);
        FaceAnimator.runtimeAnimatorController = NormalAnimationController;
        //CurrentAnimator = NormalAnimator;
    }

    void FixedUpdate()
    {
        if (KarachunState.Value >= 2)
        {
            FaceAnimator.runtimeAnimatorController = Animators[KarachunType.Value];
        }
        else
        {
            FaceAnimator.runtimeAnimatorController = Animators[3];
        }
    }

    public void EN()
    {
        FaceAnimator.SetBool("IsTalking", true);
    }

    public void DI()
    {
        FaceAnimator.SetBool("IsTalking", false);
    }
}
