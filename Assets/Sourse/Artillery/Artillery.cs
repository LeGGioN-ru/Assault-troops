using UnityEngine;
using UnityEngine.EventSystems;

public class Artillery : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Vector2 _explosionRadius;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _explosion;

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

    private void SpawnExplosion(Vector2 position)
    {
        _explosion.transform.position = position;
        _explosion.SetActive(true);    
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
        Collider2D[] colliders = Physics2D.OverlapBoxAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), _explosionRadius, 0);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Solider solider))
            {
                solider.ApplyDamage(_damage);
            }
        }

        SpawnExplosion(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        gameObject.SetActive(false);
    }
}