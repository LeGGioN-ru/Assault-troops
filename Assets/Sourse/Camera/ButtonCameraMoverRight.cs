using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCameraMoverRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CameraMover _mover;
    [SerializeField] private CameraData _data;
    [SerializeField] private bool _isRightButton = true;

    private bool _pressed = false;

    private void Update()
    {
        if(_pressed)
        {
            _mover.enabled = false;
            if(_isRightButton)
                MoveRight();
            else
                MoveLeft();
        }
        else
        {
            _mover.enabled = true;
        }
    }

    private void MoveRight()
    {
        Vector3 newPosition = new Vector3(_data.CameraMaxX, _data.Camera.transform.position.y, _data.Camera.transform.position.z);
        ChangeCameraPosition(newPosition);
    }

    private void MoveLeft()
    {
        Vector3 newPosition = new Vector3(_data.CameraMinX, _data.Camera.transform.position.y, _data.Camera.transform.position.z);
        ChangeCameraPosition(newPosition);
    }

    private void ChangeCameraPosition(Vector3 newPosition)
    {
        _data.Camera.transform.position = Vector3.MoveTowards(_data.Camera.transform.position, newPosition, 5f * Time.deltaTime);

        float distance = _data.CameraMaxX - _data.CameraMinX;
        _data.CameraScrollbar.MoveScrollbar(_data.Camera.transform.position.x / distance);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }
}