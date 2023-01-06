using System.Linq;
using UnityEngine;

public class TrenchList : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;

    private Trench[] _trenchs;

    public void SetAllTrenches()
    {
        _trenchs = GetComponentsInChildren<Trench>();
        _trenchs = _trenchs.OrderByDescending(trench => trench.transform.position.x).ToArray();

        _enemyAI.Init(_trenchs.ToList());
    }
}