using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _startMoney;
    [SerializeField] private float _incomeTime;

    private int _moneyIncome = 10;
    private float _currentTime = 0;
    private int _currentMoney;

    public event Action<int> ChangeMoneysCount;

    private void Start()
    {
        _currentMoney += _startMoney;
        ChangeMoneysCount.Invoke(_currentMoney);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _incomeTime)
        {
            _currentTime = 0f;
            _currentMoney += _moneyIncome;

            ChangeMoneysCount.Invoke(_currentMoney);
        }
    }

    public void DecreaseMoney(int money)
    {
        _currentMoney -= money;
        ChangeMoneysCount.Invoke(_currentMoney);
    }
}