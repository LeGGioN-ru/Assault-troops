using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SoundButton : MonoBehaviour
{
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private bool _isSoundEnabled = true;
    private Image _image;

    public bool IsSoundEnabled => _isSoundEnabled;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnSoundButton()
    {
        if (AudioListener.volume == 1)
        {
            _image.sprite = _soundOff;

            AudioListener.volume = 0;
            _isSoundEnabled = false;
        }
        else if(AudioListener.volume == 0)
        {
            _image.sprite = _soundOn;

            AudioListener.volume = 1;
            _isSoundEnabled = true;
        }
    }
}