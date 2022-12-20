using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Solider))]
public class EnemySoliderFinder : MonoBehaviour
{
    [SerializeField] private Vector3 _distance;

    public Solider EnemySolider => _enemySolider;

    private Solider _currentSolider;
    private Solider _enemySolider;

    private void Start()
    {
        _currentSolider = GetComponent<Solider>();
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, _distance, 0);

        if (colliders.Any(x => x.TryGetComponent(out Solider solider) && solider == _enemySolider))
            return;

        _enemySolider = null;

        foreach (Collider2D collider in colliders)
        {
            if (IsEnemySolider(collider, out Solider solider))
            {
                _enemySolider = solider;
                return;
            }
        }
    }
    private bool IsEnemySolider(Collider2D collider, out Solider enemy)
    {
        enemy = null;

        if (collider.TryGetComponent(out Solider solider) == false)
            return false;
        else
            enemy = solider;

        if (enemy == _currentSolider)
            return false;

        return true;
        //Доп проверка на команду
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _distance);
    }
}
