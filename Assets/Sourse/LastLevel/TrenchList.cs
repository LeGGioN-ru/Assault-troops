using UnityEngine;

public class TrenchList : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;
    
    private Trench[] _trenchs;

    public void SetAllTrenches()
    {
        _trenchs = GetComponentsInChildren<Trench>();

        //_enemyAI.SetTrenches(_trenchs);
    }
}