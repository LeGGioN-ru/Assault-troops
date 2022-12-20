using UnityEngine;

[RequireComponent(typeof(EnemySoliderFinder))]
public class TargetLostTransition : Transition
{
    private EnemySoliderFinder _enemySoliderFinder;

    private void Start()
    {
        _enemySoliderFinder = GetComponent<EnemySoliderFinder>();
    }

    private void Update()
    {
        if (_enemySoliderFinder.EnemySolider == null)
            IsNeedTransit = true;
    }
}
