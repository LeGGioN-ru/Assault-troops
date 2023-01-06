using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameSaver _saver;
    [SerializeField] private int _nextSceneNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Solider>(out Solider solider))
            if (solider.IsPlayerTeam)
            {
                Time.timeScale = 0;
                _saver.Save(_nextSceneNumber);
            }
    }
}