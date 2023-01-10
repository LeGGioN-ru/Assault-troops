using UnityEngine;

public class SoundButton : MonoBehaviour
{
    private bool _isSoundEnabled = true;

    public bool IsSoundEnabled => _isSoundEnabled;

    public void OnSoundButton()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            _isSoundEnabled = false;
        }
        else if(AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            _isSoundEnabled = true;
        }
    }
}