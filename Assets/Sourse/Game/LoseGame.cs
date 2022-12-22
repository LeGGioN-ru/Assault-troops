using UnityEngine;

public class LoseGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Solider>(out Solider solider))
            if (!solider.IsPlayerTeam)
            {
                Time.timeScale = 0;
                Debug.Log("Lose!");
            }
    }
}