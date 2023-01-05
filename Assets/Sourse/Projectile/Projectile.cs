using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] protected float Damage;

    private float _passedTime;
    private Vector2 _direction;
    private bool _isPlayerTeam;

    public void Init(Vector2 direction, bool isPlayerTeam)
    {
        _direction = direction;
        _isPlayerTeam = isPlayerTeam;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);

        _passedTime += Time.deltaTime;

        if (_passedTime >= _lifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Solider soldier))
            if (soldier.IsPlayerTeam != _isPlayerTeam)
                TouchEnemy(soldier, _isPlayerTeam);
    }

    abstract protected void TouchEnemy(Solider enemy, bool isPlayerTeam);
}
