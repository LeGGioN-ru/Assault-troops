using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolderBuyer : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private Image _blockClickPanel;

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
        _costText.text = _cost.ToString();
    }

    private void CheckCanBuySolder(int playerMoney)
    {
        if(playerMoney >= _cost)
            _blockClickPanel.gameObject.SetActive(false);
        else
            _blockClickPanel.gameObject.SetActive(true);
    }

    public void BuySolder()
    {
        _playerMoney.DecreaseMoney(_cost);
        SoldersSpawner.Instance.SpawnSolders();
    }
}