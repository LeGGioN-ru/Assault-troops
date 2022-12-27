using System;
using System.Collections;
using UnityEngine;

public class SolderBuyer : MonoBehaviour
{
    [SerializeField] private SoldersSpawner _spawner;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private int _cost;
    [SerializeField] private float _clickCooldown = 4;

    private float _currentTime = 0;
    private bool _isCanBuy = false;

    public int Cost => _cost;
    public float ClickCooldown => _clickCooldown;

    public event Action ButtonReady;
    public event Action<bool> ChangeIsCanBuy;
    public event Action<int> CostChanged;

    private void OnEnable()
    {
        _wallet.ChangeMoneysCount += (int money) =>
        {
            CheckCanBuySolder(money);
        };
    }

    private void OnDisable()
    {
        _wallet.ChangeMoneysCount -= (int money) =>
        {
            CheckCanBuySolder(money);
        };
    }

    private void CheckCanBuySolder(int playerMoney)
    {
        if (playerMoney >= _cost)
        {
            _isCanBuy = true;
            ChangeIsCanBuy?.Invoke(_isCanBuy);
        }
        else
        {
            _isCanBuy = false;
            ChangeIsCanBuy?.Invoke(_isCanBuy);
        }
    }

    private IEnumerator Cooldown()
    {
        _currentTime = 0;

        while (_currentTime < _clickCooldown)
        {
            _currentTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        ButtonReady?.Invoke();
    }

    public void SetPool(ObjectPoolInfo info)
    {
        _pool = info.Pool;
        _cost = info.SoldierCost;

        CostChanged?.Invoke(_cost);
    }

    public void BuySolder()
    {
        StartCoroutine(Cooldown());
        _wallet.DecreaseMoney(_cost);

        _spawner.SpawnSolders(_pool);
    }
}