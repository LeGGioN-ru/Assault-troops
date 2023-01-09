using UnityEngine;

public class SelfDestroyExplosion : MonoBehaviour
{
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
