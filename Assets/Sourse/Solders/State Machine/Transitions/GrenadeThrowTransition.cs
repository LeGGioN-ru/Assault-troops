using UnityEngine;

[RequireComponent(typeof(EnemySoliderFinder))]
public class GrenadeThrowTransition : Transition
{
    [SerializeField] private int _amountGrenade;
    [SerializeField] private float _throwDelay;

    private EnemySoliderFinder _enemySoldierFinder;
    private float _passedTime;

    private void Start()
    {
        _enemySoldierFinder = GetComponent<EnemySoliderFinder>();
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_amountGrenade > 0 && _passedTime >= _throwDelay && _enemySoldierFinder.EnemySolider != null)
        {
            _passedTime = 0;
            _amountGrenade--;
            IsNeedTransit = true;
        }
    }
}
