using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private List<EnemyAITemplate> _templates;
    [SerializeField] private LoseGame _loseZone;
    [SerializeField] private List<SolderBuyer> _soldierBuyers;

    private EnemyAITemplate _currentTemplate;
    private List<Trench> _trenches;
    private float _passedTime;
    private int _maxPercent = 100;

    private void Start()
    {
        _currentTemplate = _templates[Random.Range(0, _templates.Count)];
    }

    public void Init(List<Trench> trenches)
    {
        _trenches = trenches;
        enabled = true;
    }

    public void AddSoliderBuyer(SolderBuyer solderBuyer)
    {
        _soldierBuyers.Add(solderBuyer);
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime < _currentTemplate.TickDelay)
            return;

        _passedTime = 0;
        TryBuySolider();
        TryShootArtilery();
        TrenchMoveCalculate();
    }

    private void TrenchMoveCalculate()
    {
        TryMove();
        TryAttack();
        TryFinalAttack();
        TryWinGame();
    }

    private void TryShootArtilery()
    {
        foreach (SolderBuyer soldierBuyer in _soldierBuyers)
        {
            if (soldierBuyer.Artillery != null && soldierBuyer.IsCanBuy)
            {
                if (_currentTemplate.ChanceShootArtillery < Random.Range(0, _maxPercent + 1))
                    return;

                Trench trench = _trenches.Where(x => x.IsTrenchBusy(true)).OrderBy(trench => trench.Impact).FirstOrDefault();

                if (trench == null)
                    return;

                Transform randomTransform = trench.GetRandomSoldierTransform();
                soldierBuyer.Artillery.Execute(randomTransform.position);
            }
        }
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
    }

    private void TryBuySolider()
    {
        LoseChance currentChance = DefineCurrentChance();
        SolderBuyer pickedSolderBuyer = null;

        if (currentChance == LoseChance.Low)
            pickedSolderBuyer = _soldierBuyers.FirstOrDefault(solder => solder.Cost == _soldierBuyers.Max(solder => solder.Cost));
        else if (currentChance == LoseChance.Middle)
            pickedSolderBuyer = _soldierBuyers[Random.Range(0, _soldierBuyers.Count)];
        else
            pickedSolderBuyer = _soldierBuyers.FirstOrDefault(solder => solder.Cost == _soldierBuyers.Min(solder => solder.Cost));

        if (pickedSolderBuyer.IsCanBuy)
            pickedSolderBuyer.BuySolder();
    }

    private LoseChance DefineCurrentChance()
    {
        float currentPercentBusy = _trenches.Count(trench => trench.IsTrenchBusy(true)) / _trenches.Count;

        if (currentPercentBusy <= _currentTemplate.ChanceBuyExpensiveSoldier)
            return LoseChance.Low;
        else if (currentPercentBusy <= _currentTemplate.ChanceBuyRandomSoldier)
            return LoseChance.Middle;
        else
            return LoseChance.High;
    }

    private enum LoseChance
    {
        Low,
        Middle,
        High
    }
}
