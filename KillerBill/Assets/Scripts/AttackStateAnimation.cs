using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateAnimation : StateMachineBehaviour
{
    private static readonly int _attack = Animator.StringToHash("attack");

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.3f)
        {
            animator.SetBool(_attack, false);
        }
    }
}
