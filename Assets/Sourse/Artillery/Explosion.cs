using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void OnEndAnimation()
    {
        gameObject.SetActive(false);
    }
}