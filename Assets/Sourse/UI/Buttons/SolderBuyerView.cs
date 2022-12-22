using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(SolderBuyer))]
public class SolderBuyerView : MonoBehaviour
{
    [SerializeField] private Image _blockClickPanel;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Button _button;

    private SolderBuyer _solderBuyer;

    private void OnEnable()
    {
        _solderBuyer = GetComponent<SolderBuyer>();

        _solderBuyer.ButtonReady += () =>
        {
            SetButtonActive();
        };

        _solderBuyer.ChangeIsCanBuy += (canBuy) =>
        {
            ActiveteBlockCLickPanel(canBuy);
        };
    }

    private void OnDisable()
    {
        _solderBuyer.ButtonReady -= () =>
        {
            SetButtonActive();
        };

        _solderBuyer.ChangeIsCanBuy -= (canBuy) =>
        {
            ActiveteBlockCLickPanel(canBuy);
        };
    }

    private void Start()
    {
        _costText.text = _solderBuyer.Cost.ToString();
    }

    private void ActiveteBlockCLickPanel(bool canBuy)
    {
        if(canBuy)
            _blockClickPanel.gameObject.SetActive(false);
        else
            _blockClickPanel.gameObject.SetActive(true);
    }

    private void SetButtonActive()
    {
        _button.enabled = true;
    }

    public void OnButtonClick()
    {
        _button.enabled = false;
    }
}