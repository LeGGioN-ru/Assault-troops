using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private float _passedTime;
    private Vector2 _direction;

    public void Init(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);

        _passedTime += Time.deltaTime;

        if (_passedTime >= _lifeTime)
            Destroy(gameObject);
    }
}
