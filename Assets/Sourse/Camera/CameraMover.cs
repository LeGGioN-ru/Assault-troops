using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;

    private Camera _camera;
    private Vector3 dragOrigin;

    private float _backgroundMinX, _backgroundMaxX, _backgroundMinY, _backgroundMaxY;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        _backgroundMinX = _background.transform.position.x - _background.bounds.size.x /2f;
        _backgroundMaxX = _background.transform.position.x + _background.bounds.size.x /2f;

        _backgroundMinY = _background.transform.position.y - _background.bounds.size.y /2f;
        _backgroundMaxY = _background.transform.position.y + _background.bounds.size.y /2f;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigin = _camera.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - _camera.ScreenToWorldPoint(Input.mousePosition);

            _camera.transform.position = ClapmCamera(_camera.transform.position + difference);
        }
    }

    private Vector3 ClapmCamera(Vector3 targetPosition)
    {
        float cameraHeight = _camera.orthographicSize;
        float cameraWidth = _camera.orthographicSize * _camera.aspect;

        float minX = _backgroundMinX + cameraWidth;
        float maxX = _backgroundMaxX - cameraWidth;
        float minY = _backgroundMinY + cameraHeight;
        float maxY = _backgroundMaxY - cameraHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}