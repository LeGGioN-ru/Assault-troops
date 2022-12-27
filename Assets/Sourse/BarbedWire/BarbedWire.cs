using UnityEngine;

public class BarbedWire : MonoBehaviour
{
    [Range(0, 1)] 
    [SerializeField] private float _moveSpeedDecrease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Solider solider = collision.GetComponent<Solider>();

        if (solider == null)
            return;

        //solider.DecreaseMoveSpeed(_moveSpeedDecrease):
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Solider solider = collision.GetComponent<Solider>();

        if (solider == null)
            return;

        //solider.IncreaseMoveSpeed(_moveSpeedDecrease);
    }
}