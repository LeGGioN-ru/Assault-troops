using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuyButtonCooldown : MonoBehaviour
{
    [SerializeField] private float _clickCooldown = 4;

    private float _currentTime = 0;
    private Button _button;

    public float ClickCooldown => _clickCooldown;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void OnButtonClick()
    {
        _button.enabled = false;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        _currentTime = 0;

        while (_currentTime < _clickCooldown)
        {
            _currentTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        _button.enabled = true;
    }
}