using UnityEngine;
using UnityEngine.UI;

public class SoldersOnScrollBar : CanNormilizeValue
{
    [SerializeField] private CameraData _data;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        float maxX = SoldersSpawner.Instance.GetMaxX();

        float sliderValue = Normalize(3, 48, maxX);
        _slider.value = sliderValue;
    }
}