using UnityEngine;

public class SoldersSpawner : ObjectPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _solderPrefab;

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

    private void Start()
    {
        Initialize(_solderPrefab);   
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }

    public void SpawnSolders()
    {
        for (int i = 0; i < _soldersCount; i++)
        {
            int randomPoint = Random.Range(0, _spawnPoints.Length);

            if(TryGetObject(out GameObject enemy))
            {
                SetEnemy(enemy, _spawnPoints[randomPoint].position);
            }
        }
    }
}