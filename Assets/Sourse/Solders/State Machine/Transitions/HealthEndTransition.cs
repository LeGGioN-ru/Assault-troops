using UnityEngine;

[RequireComponent(typeof(Solider))]
public class HealthEndTransition : Transition
{
    private Solider _solider;

    private void Start()
    {
        _solider = GetComponent<Solider>();
    }

    private void Update()
    {
        if (_solider.Health <= 0)
            IsNeedTransit = true;
    }
}
