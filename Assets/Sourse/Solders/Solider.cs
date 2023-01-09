using UnityEngine;

public class Solider : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private bool _isPlayerTeam;
    [SerializeField] private float _percentMiss;
    [SerializeField] private float _impact;

    private bool _isInTrench;
    private readonly int _maxPercent = 100;
    private float _trenchPercentMiss;
    private float _currentHealth;

    public float Impact => _impact;
    public float CurrentHealth => _currentHealth;
    public bool IsPlayerTeam => _isPlayerTeam;
    public bool IsInTrench => _isInTrench;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        if (Random.Range(0, _maxPercent + 1) <= _percentMiss)
            return;

        ReduceHealth(damage);
    }

    public void DieFromArtillery()
    {
        _currentHealth = 0;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void ReduceHealth(float damage)
    {
        _currentHealth -= damage;
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
