using UnityEngine;
using UnityEngine.UI;

public class CameraScrollbarView : MonoBehaviour
{
    [SerializeField] private Scrollbar _bar;

    public void MoveScrollbar(float value)
    {
        Debug.Log(value);
        _bar.value = value;
    }
}