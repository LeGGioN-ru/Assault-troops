using System.Collections.Generic;
using UnityEngine;

public class RandomSoldiersSetter : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolInfo> _playerPools;
    [SerializeField] private SolderBuyer[] _solderBuyer;
    [SerializeField] private ButtonImageSetter[] _imageSetters;

    private void Start()
    {
        for (int i = 0; i < _solderBuyer.Length; i++)
        {
            int index = Random.Range(0, _playerPools.Capacity);

            _solderBuyer[i].SetPool(_playerPools[index]);
            _imageSetters[i].SetImage(_playerPools[index].SoldierImage);
        }
    }
}