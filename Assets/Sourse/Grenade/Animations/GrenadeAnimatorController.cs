using System;
using UnityEngine;

[Serializable]
public static class GrenadeAnimatorController
{
    public static class State
    {
        public static readonly int Fall = Animator.StringToHash(nameof(Fall));
        public static readonly int FallBack = Animator.StringToHash(nameof(FallBack));
    }
}
