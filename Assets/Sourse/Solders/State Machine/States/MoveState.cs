using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;

    private void OnEnable()
    {
        PlayAnimation(SoliderAnimationController.States.Move);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }

    public void DecreaseSpeed(float speed)
    {
        _speed -= speed;
    }

    public void IncreaseSpeed(float speed)
    {
        _speed += speed;
    }
}