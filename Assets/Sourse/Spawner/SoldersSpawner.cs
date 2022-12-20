using UnityEngine;

public class SoldersSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    private int _soldersCount = 3;

    public static SoldersSpawner Instance = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SpawnSolders()
    {
        for (int i = 0; i < _soldersCount; i++)
        {
            int randomPoint = Random.Range(0, _spawnPoints.Length);
            Debug.Log(_spawnPoints[randomPoint].gameObject.name);
        }
    }
}