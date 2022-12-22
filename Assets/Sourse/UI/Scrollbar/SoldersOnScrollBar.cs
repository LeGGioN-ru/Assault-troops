using UnityEngine;
using UnityEngine.UI;

public class SoldersOnScrollBar : MonoBehaviour
{
    [SerializeField] private CameraData _data;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        float maxX = SoldersSpawner.Instance.GetMaxX();

        float distance = _data.CameraMaxX - _data.CameraMinX;
        _slider.value = maxX / distance;
    }
}