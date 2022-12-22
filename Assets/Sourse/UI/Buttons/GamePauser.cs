using UnityEngine;
using UnityEngine.UI;

public class GamePauser : MonoBehaviour
{
    [SerializeField] private Image _gamePause;

    public void OnPauseButton()
    {
        if(Time.timeScale > 0)
        {
            _gamePause.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            _gamePause.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}