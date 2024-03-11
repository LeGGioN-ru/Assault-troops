using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraData : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CameraScrollbarView _scrollbar;

    private Camera _camera;

    private float _cameraMinX, _cameraMaxX;
    private float _backgroundMinX, _backgroundMaxX;
    private float _cameraWidth;


    public float BackgorundMinX => _backgroundMinX;
    public float BackgorundMaxX => _backgroundMaxX;
    public float CameraMinX => _cameraMinX;
    public float CameraMaxX => _cameraMaxX;
    public Camera Camera => _camera;
    public CameraScrollbarView CameraScrollbar => _scrollbar;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        _backgroundMinX = _background.transform.position.x - _background.bounds.size.x / 2f;
        _backgroundMaxX = _background.transform.position.x + _background.bounds.size.x / 2f;

        _cameraWidth = _camera.orthographicSize * _camera.aspect;

        _cameraMinX = _backgroundMinX + _cameraWidth;
        _cameraMaxX = _backgroundMaxX - _cameraWidth;
    }
}