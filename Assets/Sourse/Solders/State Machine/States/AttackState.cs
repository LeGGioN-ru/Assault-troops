using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AttackState : State
{
    [SerializeField] private float _attackSpeed;

    private float _passedTime;

    private void OnEnable()
    {
        PlayAnimation(SoliderAnimationController.States.Idle);
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime >= _attackSpeed)
        {
            Attack();
            PlayAnimation(SoliderAnimationController.States.Attack);
            _passedTime = 0;
        }
    }

    abstract protected void Attack();
}
