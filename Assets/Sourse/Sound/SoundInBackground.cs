using UnityEngine;
using Agava.WebUtility;

public class SoundInBackground : MonoBehaviour
{
    [SerializeField] private SoundButton _soundButton;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        if (_soundButton.IsSoundEnabled == false)
            return;

        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;
    }
}