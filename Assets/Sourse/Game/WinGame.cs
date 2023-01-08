using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameSaver _saver;
    [SerializeField] private int _nextSceneNumber;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Advertisement _advertisement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Solider>(out Solider solider))
            if (solider.IsPlayerTeam)
            {
                Time.timeScale = 0;

                _winPanel.SetActive(true);
                _saver.Save(_nextSceneNumber , false);
                _advertisement.ShowAd();
            }
    }
}