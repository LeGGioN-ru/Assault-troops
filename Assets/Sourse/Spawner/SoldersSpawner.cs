using UnityEngine;

public class SoldersSpawner : MonoBehaviour
{
    [SerializeField] private float yCubeSize = 8;

    private int _soldersCount = 3;

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

    public void SpawnSolders(ObjectPool _pool)
    {
        for (int i = 0; i < _soldersCount; i++)
        {
            float randomY = Random.Range(transform.position.y - yCubeSize / 2, transform.position.y + yCubeSize / 2);

            if(_pool.TryGetObject(out GameObject enemy))
            {
                Vector2 spawnPoint = new Vector2(transform.position.x, randomY);
                SetEnemy(enemy, spawnPoint);
            }
        }
    }
}