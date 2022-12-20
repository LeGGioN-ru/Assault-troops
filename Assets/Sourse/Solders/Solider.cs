using UnityEngine;

public class Solider : MonoBehaviour
{
    [SerializeField] private float _health;

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if(_health<=0)
            Destroy(gameObject);
    }
}
