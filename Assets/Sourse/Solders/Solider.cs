using UnityEngine;

public class Solider : MonoBehaviour
{
    [SerializeField] private float _health;

    private Trench _currentTrench;
    private int _maxPercent = 100;

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

        if (_health <= 0)
            Destroy(gameObject);
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
