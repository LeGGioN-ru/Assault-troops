using UnityEngine;
using UnityEngine.UI;

public class CameraScrollbarView : MonoBehaviour
{
    [SerializeField] private Scrollbar _bar;

    public void MoveScrollbar(float value)
    {
        _bar.value = value;
    }
}
