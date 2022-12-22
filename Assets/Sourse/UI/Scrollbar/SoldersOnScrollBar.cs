using UnityEngine;
using UnityEngine.UI;

public class SoldersOnScrollBar : CanNormilizeValue
{
    [SerializeField] private ObjectPool[] _pools;
    [SerializeField] private CameraData _data;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        float maxX = Mathf.NegativeInfinity;

        for (int i = 0; i < _pools.Length; i++)
        {
            float newMaxX = _pools[i].GetMaxSoldersX();

            if (newMaxX > maxX)
                maxX = newMaxX;
        }

        float sliderValue = Normalize(3, 48, maxX);
        _slider.value = sliderValue;
    }
}