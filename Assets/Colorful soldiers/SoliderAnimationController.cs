using System;
using UnityEngine;

[Serializable]
public static class SoliderAnimationController
{
    public static class States
    {
        public static readonly int Idle = Animator.StringToHash(nameof(Idle));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int Die = Animator.StringToHash(nameof(Die));
        public static readonly int SitTrench = Animator.StringToHash(nameof(SitTrench));
        public static readonly int Move = Animator.StringToHash(nameof(Move));
    }
}
