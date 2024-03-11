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
        if (_solider.CurrentHealth <= 0)
            IsNeedTransit = true;
    }
}
