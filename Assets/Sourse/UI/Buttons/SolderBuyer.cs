using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolderBuyer : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private Wallet _playerMoney;
    [SerializeField] private SolderBuyerView _view;

    private void OnEnable()
    {
        _playerMoney.ChangeMoneysCount += (int money) =>
        {
            CheckCanBuySolder(money);
        };
    }

    private void OnDisable()
    {
        _playerMoney.ChangeMoneysCount -= (int money) =>
        {
            CheckCanBuySolder(money);
        };
    }

    private void Start()
    {
        _view.SetCost(_cost.ToString());
    }

    private void CheckCanBuySolder(int playerMoney)
    {
        if (playerMoney >= _cost)
            _view.ActiveteBlockCLickPanel(false);
        else
            _view.ActiveteBlockCLickPanel(true);
    }

    public void BuySolder(int solderIndex)
    {
        _playerMoney.DecreaseMoney(_cost);
        SoldersSpawner.Instance.SpawnSolders(solderIndex);
    }
}