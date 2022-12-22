using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolderBuyerView : MonoBehaviour
{
    [SerializeField] private Image _blockClickPanel;
    [SerializeField] private TMP_Text _costText;

    public void ActiveteBlockCLickPanel(bool isActive)
    {
        if (isActive)
            _blockClickPanel.gameObject.SetActive(true);
        else
            _blockClickPanel.gameObject.SetActive(false);
    }

    public void SetCost(string cost)
    {
        _costText.text = cost;
    }
}
