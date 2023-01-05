using UnityEngine;

[RequireComponent(typeof(EnemySoliderFinder))]
public class AttackOneTargetState : AttackState
{
    [SerializeField] private float _damage;

    private EnemySoliderFinder _enemySoliderFinder;

    private void Start()
    {
        _enemySoliderFinder = GetComponent<EnemySoliderFinder>();
    }

    protected override void Attack()
    {
        _enemySoliderFinder.EnemySolider.ApplyDamage(_damage);
    }
}
