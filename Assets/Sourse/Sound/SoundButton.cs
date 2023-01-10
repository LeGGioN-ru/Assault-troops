using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public void OnSoundButton()
    {
        if (AudioListener.volume == 1)
            AudioListener.volume = 0;
        else if(AudioListener.volume == 0)
            AudioListener.volume = 1;
    }
}