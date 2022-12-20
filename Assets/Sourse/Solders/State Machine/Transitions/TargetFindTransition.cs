using UnityEngine;

[RequireComponent(typeof(EnemySoliderFinder))]
public class TargetFindTransition : Transition
{
    private EnemySoliderFinder _enemySoliderFinder;

    private void Start()
    {
        _enemySoliderFinder = GetComponent<EnemySoliderFinder>();
    }

    private void Update()
    {
        if (_enemySoliderFinder.EnemySolider != null)
            IsNeedTransit = true;
    }
}
