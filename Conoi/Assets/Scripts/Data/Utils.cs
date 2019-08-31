using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Utils : MonoBehaviour
{
    public static bool AnimationIsFinished(Animator anim)
    {
        if (anim.isActiveAndEnabled)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                return true;
            else
                return false;
        }
        else
            return false;

    }
}
