using UnityEngine;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Solider solider = collision.gameObject.GetComponent<Solider>();

        if (solider.IsPlayerTeam)
        {
            Time.timeScale = 0;
            Debug.Log("Win!");
        }
    }
}