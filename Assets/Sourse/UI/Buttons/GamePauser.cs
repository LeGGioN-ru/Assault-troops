using UnityEngine;
using UnityEngine.UI;

public class GamePauser : MonoBehaviour
{
    [SerializeField] private Image _gamePause;
    [SerializeField] private SoundButton _soundButton;

    public void DisableSound()
    {
        if (_soundButton.IsSoundEnabled == false)
            return;

        if (AudioListener.volume == 1)
            AudioListener.volume = 0;
        else if (AudioListener.volume == 0)
            AudioListener.volume = 1;
    }

    public void OnPauseButton()
    {
        if(Time.timeScale > 0)
        {
            _gamePause.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            _gamePause.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}