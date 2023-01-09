using UnityEngine;

[CreateAssetMenu(fileName = "New enemy template", menuName = "AI/Create new enemy template", order = 51)]
public class EnemyAITemplate : ScriptableObject
{
    [SerializeField] private float _tickDelay;
    [SerializeField] private float _coefficientFear;
    [SerializeField] private float _finalAttackImpact;
    [SerializeField] private float _moveDelay;
    [SerializeField] private float _chanceBuyExpensiveSoldier;
    [SerializeField] private float _chanceBuyRandomSoldier;

    public float MoveDelay => _moveDelay;
    public float TickDelay => _tickDelay;
    public float CoefficientFear => _coefficientFear;
    public float FinalAttackImpact => _finalAttackImpact;
    public float ChanceBuyExpensiveSoldier => _chanceBuyExpensiveSoldier;
    public float ChanceBuyRandomSoldier => _chanceBuyRandomSoldier;
}
