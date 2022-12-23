using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPoolManager : NormalizedValueGetter
{
    [SerializeField] private ObjectPool[] _playersPools;
    [SerializeField] private ObjectPool[] _enemyPools;
    [SerializeField] private CameraData _data;

    private float _minX, _maxX;

    public event Action<float> MinXChanged;
    public event Action<float> MaxXChanged;

    private void Update()
    {
        SetMaxX();
        SetMinX();
    }

    private void SetMaxX()
    {
        float maxX = Mathf.NegativeInfinity;

        for (int i = 0; i < _playersPools.Length; i++)
        {
            float newMaxX = _playersPools[i].GetMaxSoldersX();

            if (newMaxX > maxX)
                maxX = newMaxX;
        }

        _maxX = GetNormilizedValue(_data.BackgorundMinX, _data.BackgorundMaxX, maxX);
        MaxXChanged?.Invoke(_maxX);
    }

    private void SetMinX()
    {
        float minX = Mathf.Infinity;

        for (int i = 0; i < _enemyPools.Length; i++)
        {
            float newMinX = _enemyPools[i].GetMinSoldersX();

            if (newMinX < minX)
                minX = newMinX;
        }

        _minX = GetNormilizedValue(_data.BackgorundMinX, _data.BackgorundMaxX, minX);
        MinXChanged?.Invoke(_minX);
    }
}