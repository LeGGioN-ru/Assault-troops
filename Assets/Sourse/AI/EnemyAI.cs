using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private SolderBuyer _solderBuyer;
    [SerializeField] private float _tickDelay;
    [SerializeField] private float _coefficientFear;
    [Header("Point in strict order from the side of the enemy")]
    [SerializeField] private List<Trench> _trenches;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _finalAttackImpact;

    private Wallet _wallet;
    private float _passedTime;
    private float _passedTimeSpawn;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
        TryBuySolider();
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;
        _passedTimeSpawn += Time.deltaTime;

        if (_passedTime < _tickDelay)
            return;

        _passedTime = 0;
        TryBuySolider();
        TrenchMoveCalculate();
    }

    private void TrenchMoveCalculate()
    {
        TryMove();
        TryAttack();
        TryFinalAttack();
    }

    private void TryFinalAttack()
    {
        Trench lastTrench = _trenches.Last();

        if (lastTrench.IsTrenchBusy(false) && lastTrench.Impact >= _finalAttackImpact)
            lastTrench.GetUpAllSoliders();
    }

    private void TryAttack()
    {
        for (int i = 0; i < _trenches.Count; i++)
        {
            if (i + 1 < _trenches.Count)
            {
                if (_trenches[i + 1].IsTrenchBusy(true) && _trenches[i].IsTrenchBusy(false))
                {
                    float enemyTrenchImpact = _trenches[i].Impact;
                    float playerTrenchImpact = _trenches[i + 1].Impact;

                    if (enemyTrenchImpact / playerTrenchImpact >= _coefficientFear)
                        _trenches[i].GetUpAllSoliders();
                }
            }
        }
    }

    private void TryMove()
    {
        for (int i = 0; i < _trenches.Count; i++)
        {
            if (i + 1 < _trenches.Count)
                if (_trenches[i + 1].IsTrenchBusy(true) == false && _trenches[i].IsTrenchBusy(false))
                    _trenches[i].GetUpAllSoliders();
        }
    }

    private void TryBuySolider()
    {
        if (_wallet.MoneyCount > _solderBuyer.Cost && _passedTimeSpawn >= _spawnDelay)
        {
            _solderBuyer.BuySolder();
            _passedTimeSpawn = 0;
        }
    }

    //private Risk _currentRisk;
    //private Risk IdentifyRisks()
    //{
    //    int countBusyTrenches = 0;

    //    foreach (Trench trench in _trenches)
    //        if (trench.IsTrenchBusy(true))
    //            countBusyTrenches++;

    //    float percentBusy = countBusyTrenches / _trenches.Count * 100;

    //    if (percentBusy <= 25)
    //        return Risk.Easy;
    //    else if (percentBusy <= 50)
    //        return Risk.Normal;
    //    else
    //        return Risk.Hard;
    //}

    //private enum Risk
    //{
    //    Easy = 25,
    //    Normal = 50,
    //    Hard = 75
    //}
}
