using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Wallet _playerMoney;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _playerMoney.ChangeMoneysCount += (int money) =>
        {
            ShowMoneyCount(money);
        };
    }

    private void OnDisable()
    {
        _playerMoney.ChangeMoneysCount -= (int money) =>
        {
            ShowMoneyCount(money);
        };
    }

    public void ShowMoneyCount(int money)
    {
        _text.text = money.ToString();
    }
}