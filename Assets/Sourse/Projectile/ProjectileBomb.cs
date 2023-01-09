using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBomb : Projectile
{
    [SerializeField] private Vector2 _sizeBlowUp;
    [SerializeField] private Explosion _explosion;

    protected override void TouchEnemy(Solider enemy, bool isPlayerTeam)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, _sizeBlowUp, 0);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Solider solider))
            {
                if (solider.IsPlayerTeam != isPlayerTeam)
                    solider.ApplyDamage(Damage);
            }
        }

        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_sizeBlowUp.x, _sizeBlowUp.y));
    }
}
