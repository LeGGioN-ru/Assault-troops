using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private void OnEnable()
    {
        PlayAnimation(SoliderAnimationController.States.Die);
    }
}
