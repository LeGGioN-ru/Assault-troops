using UnityEngine;

[CreateAssetMenu(fileName = "New enemy template", menuName = "AI/Create new enemy template", order = 51)]
public class EnemyAITemplate : ScriptableObject
{
    [SerializeField] private float _tickDelay;
    [SerializeField] private float _coefficientFear;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _finalAttackImpact;
    [SerializeField] private float _moveDelay;

    public float MoveDelay => _moveDelay;
    public float TickDelay => _tickDelay;
    public float CoefficientFear => _coefficientFear;
    public float SpawnDelay => _spawnDelay;
    public float FinalAttackImpact => _finalAttackImpact;
}
