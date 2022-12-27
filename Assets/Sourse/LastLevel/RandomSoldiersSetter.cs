using System.Collections.Generic;
using UnityEngine;

public class RandomSoldiersSetter : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolInfo> _playerPools;
    [SerializeField] private SoldierInfoSetter[] _imageSetters;

    private void Start()
    {
        for (int i = 0; i < _imageSetters.Length; i++)
        {
            int index = Random.Range(0, _playerPools.Capacity);

            _imageSetters[i].SetInfo(_playerPools[index]);
        }
    }
}