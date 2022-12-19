using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonProgressBar : MonoBehaviour
{
    [SerializeField] private Image[] _progressBar;
    [SerializeField] private ButtonClickCooldown _buttonClickCooldown;

    private float _currentTime = 0;
    private float _maxTime;
    private int _currentProgressBarIndex = 0;

    private void Start()
    {
        _maxTime = _buttonClickCooldown.ClickCooldown / _progressBar.Length;
    }

    private void SetBarRed()
    {
        for (int i = 0; i < _progressBar.Length; i++)
        {
            _progressBar[i].color = Color.red;
        }
    }

    private IEnumerator FillProgressBar()
    {
        while(_currentProgressBarIndex < _progressBar.Length)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _maxTime)
            {
                _currentTime = 0;
                _progressBar[_currentProgressBarIndex].color = Color.green;

                _currentProgressBarIndex++;
            }

            yield return new WaitForEndOfFrame();
        }

        _currentProgressBarIndex = 0;
    }

    public void OnButtonClick()
    {
        SetBarRed();
        StartCoroutine(FillProgressBar());
    }
}