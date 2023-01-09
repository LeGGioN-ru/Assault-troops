using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSoldiersSetter : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolInfo> _playerPools;
    [SerializeField] private SoldierInfoSetter[] _setters;
    [SerializeField] private List<ObjectPoolInfo> _enemyPools;
    [SerializeField] private SoldierInfoSetter[] _enemySetters;

    private List<ObjectPoolInfo> _playerPoolsForSetters = new List<ObjectPoolInfo>();

    private void Start()
    {
        for (int i = 0; i < _setters.Length; i++)
        {
            int index = Random.Range(0, _playerPools.Count);

            _playerPoolsForSetters.Add(_playerPools[index]);
            _playerPools.RemoveAt(index);

            _enemySetters[i].SetInfo(_enemyPools[index]);
            _enemyPools.RemoveAt(index);
        }

        SortPools();
    }

    private void SortPools()
    {
        int i = 0;
        var sortedPlayerPools = _playerPoolsForSetters.OrderBy(p => p.SoldierCost);

        foreach (var pool in sortedPlayerPools)
        {
            _setters[i].SetInfo(pool);
            i++;
        }
    }
}