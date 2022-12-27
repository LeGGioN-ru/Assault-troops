using UnityEngine;
using UnityEngine.UI;

public class SoldierInfoSetter : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private SolderBuyer _solderBuyer;

    public void SetInfo(ObjectPoolInfo info)
    {
        _solderBuyer.SetPool(info);
        _image.sprite = info.SoldierImage;
    }
}