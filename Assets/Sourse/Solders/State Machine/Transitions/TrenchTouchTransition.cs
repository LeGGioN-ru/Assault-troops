using UnityEngine;

[RequireComponent(typeof(Solider))]
public class TrenchTouchTransition : Transition
{
    private Solider _solider;

    private void Start()
    {
        _solider = GetComponent<Solider>();
    }

    private void Update()
    {
        if (_solider.IsInTrench)
            IsNeedTransit = true;
    }
}
