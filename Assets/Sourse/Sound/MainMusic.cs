using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMusic : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clips;

    private AudioSource _sourse;

    private void Start()
    {
        _sourse = GetComponent<AudioSource>();

        //_sourse.clip = _clips[0];
        _sourse.Play();
    }

    private void Update()
    {
        /*if (_sourse.isPlaying == false)
        {
            ChooseRandomClip();
        }*/
    }

    private void ChooseRandomClip()
    {
        int index = Random.Range(0, _clips.Count);

        _sourse.clip = _clips[index];
        _sourse.Play();
    }
}