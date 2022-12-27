using UnityEngine;

public class BarbedWire : MonoBehaviour
{
    [Range(0, 1)] 
    [SerializeField] private float _moveSpeedDecrease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<MoveState>(out MoveState soldier))
            soldier.DecreaseSpeed(_moveSpeedDecrease);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MoveState>(out MoveState soldier))
            soldier.IncreaseSpeed(_moveSpeedDecrease);
    }
}