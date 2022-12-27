using System.Collections.Generic;
using UnityEngine;

public class RandomSoldiersSetter : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolInfo> _playerPools;
    [SerializeField] private SoldierInfoSetter[] _setters;

    private void Start()
    {
        for (int i = 0; i < _setters.Length; i++)
        {
            int index = Random.Range(0, _playerPools.Count);

            _setters[i].SetInfo(_playerPools[index]);
            _playerPools.RemoveAt(index);
        }
    }
}