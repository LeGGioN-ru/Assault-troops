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
    [SerializeField] private bool _isArtilley = false;
    [SerializeField] private Artillery _artillery;

    private float _currentTime = 0;
    private bool _isCanBuy = false;
    private bool _isCooldown = false;

    public Artillery Artillery => _artillery;
    public bool IsCanBuy => _isCanBuy;
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

    private void Start()
    {
        CostChanged?.Invoke(_cost);
    }

    private void CheckCanBuySolder(int playerMoney)
    {
        if (playerMoney >= _cost)
        {
            if(_isCooldown == false)
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
        else
        {
            _isCanBuy = false;
            ChangeIsCanBuy?.Invoke(_isCanBuy);
        }
    }

    private IEnumerator Cooldown()
    {
        _isCooldown = true;
        _currentTime = 0;

        while (_currentTime < _clickCooldown)
        {
            _currentTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        _isCooldown = false;
        ButtonReady?.Invoke();
    }

    private void SpawnArtilleryScope()
    {
        _artillery.gameObject.SetActive(true);
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

        if (_isArtilley)
            SpawnArtilleryScope();
        else
            _spawner.SpawnSolders(_pool);
    }
}