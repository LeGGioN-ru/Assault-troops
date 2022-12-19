using UnityEngine;

public class SoldersSpawner : MonoBehaviour
{
	public static SoldersSpawner Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void SpawnSolders()
    {

    }
}