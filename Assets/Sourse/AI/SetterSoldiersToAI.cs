using UnityEngine;

public class SetterSoldiersToAI : MonoBehaviour
{
    [SerializeField] private SolderBuyer[] _solderBuyers;
    [SerializeField] private EnemyAI _enemyAI;

    private void Start()
    {
        for (int i = 0; i < _solderBuyers.Length; i++)
        {
            _enemyAI.AddSoliderBuyer(_solderBuyers[i]);
        }
    }
}