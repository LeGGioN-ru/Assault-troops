using UnityEngine;

[RequireComponent(typeof(EnemySoliderFinder))]
[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;

    private EnemySoliderFinder _enemySoliderFinder;
    private float _passedTime;

    private void Start()
    {
        _enemySoliderFinder = GetComponent<EnemySoliderFinder>();
    }

    private void OnEnable()
    {
        PlayAnimation(SoliderAnimationController.States.Attack);
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime >= _attackSpeed)
        {
            _enemySoliderFinder.EnemySolider.ApplyDamage(_damage);
            _passedTime = 0;
        }
    }
}
