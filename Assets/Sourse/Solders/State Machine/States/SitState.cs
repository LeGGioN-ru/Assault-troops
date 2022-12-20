using UnityEngine;

[RequireComponent(typeof(Solider))]
public class SitState : State
{
    private Solider _solider;

    private void Start()
    {
        _solider = GetComponent<Solider>();
    }
}
