using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ObjectPoolInfo : MonoBehaviour
{
    [SerializeField] private int _soldierCost;
    [SerializeField] private Sprite _soldierImage;  

    private ObjectPool _pool;

    public int SoldierCost => _soldierCost;
    public Sprite SoldierImage => _soldierImage;
    public ObjectPool Pool => _pool;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
    }
}