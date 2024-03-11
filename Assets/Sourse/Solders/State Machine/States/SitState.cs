using UnityEngine;

[RequireComponent(typeof(Solider))]
public class SitState : State
{
    private Solider _solider;

    private void OnEnable()
    {
        PlayAnimation(SoliderAnimationController.States.SitTrench);
    }

    private void Start()
    {
        _solider = GetComponent<Solider>();
    }
}
