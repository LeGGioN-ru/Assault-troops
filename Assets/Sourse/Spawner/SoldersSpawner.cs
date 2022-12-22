using UnityEngine;

public class SoldersSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool[] _pools;
    [SerializeField] private float yCubeSize = 8;

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2(1, yCubeSize));
    }

    private void SetEnemy(GameObject enemy, Vector2 spawnPoint)
    {
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }

    public void SpawnSolders(int solderIndex)
    {
        for (int i = 0; i < _soldersCount; i++)
        {
            float randomY = Random.Range(transform.position.y - yCubeSize / 2, transform.position.y + yCubeSize / 2);

            if(_pools[solderIndex].TryGetObject(out GameObject enemy))
            {
                Vector2 spawnPoint = new Vector2(transform.position.x, randomY);
                SetEnemy(enemy, spawnPoint);
            }
        }
    }

    public float GetMaxX()
    {
        float maxX = Mathf.NegativeInfinity;

        for (int i = 0; i < _pools.Length; i++)
        {
            float x = _pools[i].GetMaxSoldersX();

            if (x > maxX)
                maxX = x;
        }

        return maxX;
    }
}