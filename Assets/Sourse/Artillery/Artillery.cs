using UnityEngine;
using UnityEngine.EventSystems;

public class Artillery : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Vector2 _explosionRadius;
    [SerializeField] private float _damage;

    private RectTransform _transform;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Camera.main.ScreenToWorldPoint(transform.position), _explosionRadius);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Execute(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void Execute(Vector2 point)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(point, _explosionRadius, 0);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Solider solider))
            {
                solider.ApplyDamage(_damage);
            }
        }

        gameObject.SetActive(false);
    }
}