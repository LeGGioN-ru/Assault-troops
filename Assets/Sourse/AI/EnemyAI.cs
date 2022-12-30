using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private SolderBuyer _solderBuyer;
    [SerializeField] private List<EnemyAITemplate> _templates;
    [SerializeField] private LoseGame _loseZone;

    private EnemyAITemplate _currentTemplate;
    private List<Trench> _trenches;
    private Wallet _wallet;
    private float _passedTime;
    private float _passedTimeSpawn;
    private float _passedTimeMove;
    private Coroutine _moveCoroutine;

    public void Init(List<Trench> trenches)
    {
        _wallet = GetComponent<Wallet>();
        TryBuySolider();
        _currentTemplate = _templates[Random.Range(0, _templates.Count)];

        _trenches = trenches;
        enabled = true;
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;
        _passedTimeSpawn += Time.deltaTime;

        if (_passedTime < _currentTemplate.TickDelay)
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
        TryWinGame();
    }

    private void TryFinalAttack()
    {
        Trench lastTrench = _trenches.Last();

        if (lastTrench.IsTrenchBusy(false) && lastTrench.Impact >= _currentTemplate.FinalAttackImpact)
            lastTrench.GetUpAllSoliders();
    }

    private void TryWinGame()
    {
        if (_trenches[_trenches.Count - 1].IsTrenchBusy(false))
            _trenches[_trenches.Count - 1].GetUpAllSoliders();
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

                    if (enemyTrenchImpact / playerTrenchImpact >= _currentTemplate.CoefficientFear)
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
                    StartCoroutine(TryFinalMove(_trenches[i], _trenches[i + 1]));
        }
    }

    private IEnumerator TryFinalMove(Trench currentTrench, Trench nextTrench)
    {
        yield return new WaitForSeconds(_currentTemplate.MoveDelay);

        if (currentTrench.IsTrenchBusy(false) && nextTrench.IsTrenchBusy(true) == false)
            currentTrench.GetUpAllSoliders();

        _passedTimeMove = 0;
    }

    private void TryBuySolider()
    {
        if (_wallet.MoneyCount > _solderBuyer.Cost && _passedTimeSpawn >= _currentTemplate.SpawnDelay)
        {
            _solderBuyer.BuySolder();
            _passedTimeSpawn = 0;
        }
    }
}
