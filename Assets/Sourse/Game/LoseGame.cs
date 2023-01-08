using UnityEngine;

public class LoseGame : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Advertisement _advertisement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Solider>(out Solider solider))
            if (!solider.IsPlayerTeam)
            {
                Time.timeScale = 0;

                _losePanel.SetActive(true);
                _advertisement.ShowAd();
            }
    }
}