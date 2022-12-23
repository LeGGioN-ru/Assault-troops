using UnityEngine;
using UnityEngine.UI;

public class CameraScrollbar : NormalizedValueGetter
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraData _data;
    [SerializeField] private Scrollbar _scrollbar;

    private void Update()
    {
        float scrollBarValue = GetNormilizedValue(_data.CameraMinX, _data.CameraMaxX, _camera.transform.position.x);
        _scrollbar.value = scrollBarValue;
    }   
}