using System.Collections.Generic;
using UnityEngine;

public class RandomBuildingsSetter : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            int index = Random.Range(0, _prefabs.Count);

            SpawnBuilding(_prefabs[index], _spawnPoints[i]);

            _prefabs.RemoveAt(index);
        }
    }

    private void SpawnBuilding(GameObject prefab, Transform spawnPoint)
    {
        if(prefab != null)
            Instantiate(prefab, spawnPoint);
    }
}