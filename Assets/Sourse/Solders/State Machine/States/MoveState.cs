using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }
}
