using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Explosion : MonoBehaviour
{
    private AudioSource _sourse;

    private void OnEnable()
    {
        _sourse = GetComponent<AudioSource>();
        _sourse.Play();
    }

    public void OnEndAnimation()
    {
        gameObject.SetActive(false);
    }
}