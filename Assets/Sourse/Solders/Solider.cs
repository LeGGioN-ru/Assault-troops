using UnityEngine;

public class Solider : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private bool _isPlayerTeam;
    [SerializeField] private float _percentMiss;

    private bool _isInTrench;
    private readonly int _maxPercent = 100;
    private float _trenchPercentMiss;

    public float Health => _health;
    public bool IsPlayerTeam => _isPlayerTeam;
    public bool IsInTrench => _isInTrench;

    public void ApplyDamage(float damage)
    {
        if (Random.Range(0, _maxPercent + 1) > _percentMiss)
        {
            ReduceHealth(damage);
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

    public void SitTrench(float percentMiss)
    {
        _isInTrench = true;
        _trenchPercentMiss += percentMiss;
        _percentMiss += _trenchPercentMiss;
    }

    public void GetUpTrech()
    {
        _isInTrench = false;
        _percentMiss -= _trenchPercentMiss;
        _trenchPercentMiss = 0;
    }
}
