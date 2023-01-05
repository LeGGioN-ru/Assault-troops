using UnityEngine;

[RequireComponent(typeof(Solider))]
public class AttackProjectileState : AttackState
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private Transform _shootPoint;

    private bool _isPlayerTeam;

    private void Start()
    {
        _isPlayerTeam = GetComponent<Solider>().IsPlayerTeam;
    }

    protected override void Attack()
    {
        Instantiate(_projectile, _shootPoint).Init(_direction, _isPlayerTeam);
    }
}
