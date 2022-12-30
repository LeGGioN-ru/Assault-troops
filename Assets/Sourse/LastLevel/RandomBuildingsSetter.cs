using System.Collections.Generic;
using UnityEngine;

public class RandomBuildingsSetter : MonoBehaviour
{
    [SerializeField] private TrenchList _trenchList;
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRateTrench;
    [SerializeField] private float _spawnRateBarbedWire;
    [SerializeField] private float _spawnRatePuddels;
    [SerializeField] private float _spawnRateNone;

    private List<float> _spawnRate = new List<float>();

    private void Start()
    {
        _spawnRate.Add(_spawnRateTrench);
        _spawnRate.Add(_spawnRateBarbedWire);
        _spawnRate.Add(_spawnRatePuddels);
        _spawnRate.Add(_spawnRateNone);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            int index = ChooseRandomBuilding();

            SpawnBuilding(_prefabs[index], _spawnPoints[i]);
        }

        _trenchList.SetAllTrenches();
    }


    private void SpawnBuilding(GameObject prefab, Transform spawnPoint)
    {
        if (prefab != null)
            Instantiate(prefab, spawnPoint.position, Quaternion.identity, _trenchList.gameObject.transform);
    }

    private int ChooseRandomBuilding()
    {
        float total = 0;

        foreach (float elem in _spawnRate)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < _spawnRate.Count; i++)
        {
            if (randomPoint < _spawnRate[i])
            {
                return i;
            }
            else
            {
                randomPoint -= _spawnRate[i];
            }
        }

        return _spawnRate.Count - 1;
    }
}