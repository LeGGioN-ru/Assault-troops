using UnityEngine;
using UnityEngine.UI;

public class SoldersOnSlider : MonoBehaviour
{
    [SerializeField] private ObjectPoolManager _manager;
    [SerializeField] private Slider _playerSlider;
    [SerializeField] private Slider _enemySlider;

    private void OnEnable()
    {
        _manager.MinXChanged += (value) =>
        {
            SetEnemySliderValue(value);
        };

        _manager.MaxXChanged += (value) =>
        {
            SetPlayerSliderValue(value);
        };
    }

    private void SetPlayerSliderValue(float value)
    {
        _playerSlider.value = value;
    }

    private void SetEnemySliderValue(float value)
    {
        _enemySlider.value = value;
    }
}