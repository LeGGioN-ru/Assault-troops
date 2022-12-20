using UnityEngine;

public class Trench : MonoBehaviour
{
    [SerializeField] private float _percentMiss;

    public float PercentMiss => _percentMiss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Solider solider))
        {
            solider.SitTrench(this);
        }
    }
}
