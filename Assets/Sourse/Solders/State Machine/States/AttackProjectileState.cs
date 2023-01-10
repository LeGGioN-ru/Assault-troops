using UnityEngine;

[RequireComponent(typeof(Solider))]
[RequireComponent(typeof(EnemySoliderFinder))]
public class AttackProjectileState : AttackState
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private Transform _shootPoint;

    private EnemySoliderFinder _enemySoliderFinder;
    private bool _isPlayerTeam;

    private void Start()
    {
        _enemySoliderFinder = GetComponent<EnemySoliderFinder>();
        _isPlayerTeam = GetComponent<Solider>().IsPlayerTeam;
    }

    protected override void Attack()
    {
        Vector2 shootDirection = -(transform.position - _enemySoliderFinder.EnemySolider.transform.position).normalized;

        Instantiate(_projectile, _shootPoint).Init(shootDirection, _isPlayerTeam);
    }
}
