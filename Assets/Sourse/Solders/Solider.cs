using UnityEngine;

public class Solider : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private bool _isPlayerTeam;

    private Trench _currentTrench;
    private readonly int _maxPercent = 100;

    public float Health => _health;
    public bool IsPlayerTeam => _isPlayerTeam;
    public bool IsHasTrench => _currentTrench != null;

    public void ApplyDamage(float damage)
    {
        if (_currentTrench != null)
        {
            if (Random.Range(0, _maxPercent + 1) > _currentTrench.PercentMiss)
            {
                ReduceHealth(damage);
            }
        }
        else
        {
            ReduceHealth(damage);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void ReduceHealth(float damage)
    {
        _health -= damage;
    }

    public void SitTrench(Trench trench)
    {
        _currentTrench = trench;
    }

    public void GetUpTrech()
    {
        _currentTrench = null;
    }
}
