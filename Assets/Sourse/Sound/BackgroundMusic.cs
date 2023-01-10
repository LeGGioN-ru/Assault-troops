using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clips;

    private AudioSource _sourse;

    private void Start()
    {
        _sourse = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_sourse.isPlaying == false)
        {
            ChooseRandomClip();
        }
    }

    private void ChooseRandomClip()
    {
        int index = Random.Range(0, _clips.Count);

        _sourse.clip = _clips[index];
        _sourse.Play();
    }
}