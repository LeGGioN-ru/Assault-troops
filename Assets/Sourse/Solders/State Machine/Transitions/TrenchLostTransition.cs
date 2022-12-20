using UnityEngine;

[RequireComponent(typeof(Solider))]
public class TrenchLostTransition : Transition
{
    private Solider _solider;

    private void Start()
    {
        _solider = GetComponent<Solider>();
    }

    private void Update()
    {
        if (_solider.IsHasTrench == false)
            IsNeedTransit = true;
    }
}
