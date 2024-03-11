using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCameraMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CameraMover _mover;
    [SerializeField] private CameraData _data;
    [SerializeField] private bool _isRightButton = true;

    private bool _buttonPressed = false;

    private void Update()
    {
        if(_buttonPressed)
        {
            _mover.enabled = false;

            if (_isRightButton)
                ChangeCameraPosition(_data.CameraMaxX);
            else
                ChangeCameraPosition(_data.CameraMinX);
        }
        else
        {
            _mover.enabled = true;
        }
    }

    private void ChangeCameraPosition(float cameraBorderPosition)
    {
        Vector3 newPosition = new Vector3(cameraBorderPosition, _data.Camera.transform.position.y, _data.Camera.transform.position.z);
        _data.Camera.transform.position = Vector3.MoveTowards(_data.Camera.transform.position, newPosition, 5f * Time.deltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _buttonPressed = false;
    }
}