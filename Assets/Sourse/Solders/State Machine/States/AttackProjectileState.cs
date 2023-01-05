using UnityEngine;

public class AttackProjectileState : AttackState
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Vector2 _direction;

    protected override void Attack()
    {
        Instantiate(_projectile).Init(_direction);
    }
}
