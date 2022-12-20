using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CameraScrollbarView _cameraScrollbar;

    private Camera _camera;
    private Vector3 dragOrigin;

    private float _backgroundMinX, _backgroundMaxX;
    private float _cameraWidth;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        _backgroundMinX = _background.transform.position.x - _background.bounds.size.x /2f;
        _backgroundMaxX = _background.transform.position.x + _background.bounds.size.x /2f;

        _cameraWidth = _camera.orthographicSize * _camera.aspect;
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

            Vector3 newX = new Vector3(ClapmCamera(_camera.transform.position.x + difference.x), _camera.transform.position.y, _camera.transform.position.z);
            _camera.transform.position = newX;
        }
    }

    private float ClapmCamera(float targetPositionX)
    {
        float minX = _backgroundMinX + _cameraWidth;
        float maxX = _backgroundMaxX - _cameraWidth;

        float newX = Mathf.Clamp(targetPositionX, minX, maxX);

        float distance = maxX - minX;
        _cameraScrollbar.MoveScrollbar(newX / distance);

        return newX;
    }
}