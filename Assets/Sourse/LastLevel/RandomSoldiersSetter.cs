using System.Collections.Generic;
using UnityEngine;

public class RandomSoldiersSetter : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolInfo> _playerPools;
    [SerializeField] private SoldierInfoSetter[] _setters;
    [SerializeField] private List<ObjectPoolInfo> _enemyPools;
    [SerializeField] private SoldierInfoSetter[] _enemySetters;

    private void Start()
    {
        for (int i = 0; i < _setters.Length; i++)
        {
            int index = Random.Range(0, _playerPools.Count);

            _setters[i].SetInfo(_playerPools[index]);
            _playerPools.RemoveAt(index);

            //_enemySetters[i].SetInfo(_enemyPools[index]);
            //_enemyPools.RemoveAt(index);
        }
    }
}