using UnityEngine;
using UnityEngine.UI;

public class SoldierInfoSetter : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private SolderBuyer _solderBuyer;
    [SerializeField] private bool _isPlayer = true;

    public void SetInfo(ObjectPoolInfo info)
    {
        _solderBuyer.SetPool(info);

        if(_isPlayer)
            _image.sprite = info.SoldierImage;
    }
}