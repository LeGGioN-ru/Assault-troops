using UnityEngine;
using UnityEngine.UI;

public class ButtonImageSetter : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetImage(Sprite image)
    {
        _image.sprite = image;
    }
}
