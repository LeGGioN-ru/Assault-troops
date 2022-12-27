using UnityEngine;

public class Puddle : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _moveSpeedDecrease;
    [Range(0, 100)]
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MoveState>(out MoveState soldier))
        {
            soldier.DecreaseSpeed(_moveSpeedDecrease);
            collision.GetComponent<Solider>().ApplyDamage(_damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MoveState>(out MoveState soldier))
            soldier.IncreaseSpeed(_moveSpeedDecrease);
    }
}
