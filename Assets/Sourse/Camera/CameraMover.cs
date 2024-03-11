using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CameraData _data;

    private Vector3 dragOrigin;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigin = _data.Camera.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - _data.Camera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 newX = new Vector3(ClapmCamera(_data.Camera.transform.position.x + difference.x), _data.Camera.transform.position.y, _data.Camera.transform.position.z);
            _data.Camera.transform.position = newX;
        }
    }

    private float ClapmCamera(float targetPositionX)
    {
        float newX = Mathf.Clamp(targetPositionX, _data.CameraMinX, _data.CameraMaxX);

        return newX;
    }
}