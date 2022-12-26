using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ObjectPoolInfo : MonoBehaviour
{
    [SerializeField] private int _soldierCost;
    [SerializeField] private Sprite _soldierImage;  

    private ObjectPool _pool;

    private void Start()
    {
        _pool = GetComponent<ObjectPool>();
    }

    public int SoldierCost => _soldierCost;
    public Sprite SoldierImage => _soldierImage;
    public ObjectPool Pool => _pool;
}