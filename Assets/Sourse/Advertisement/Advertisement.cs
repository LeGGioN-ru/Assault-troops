using System;
using System.Collections;
using UnityEngine;
using Agava.YandexGames;

public class Advertisement : MonoBehaviour
{
    [SerializeField] private AudioListener _listener;

    private event Action onOpenAd;
    private event Action<bool> onCloseAd;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private void OnEnable()
    {
        onCloseAd += (bool isClosed) =>
        {
            SetActiveAudioListener(isClosed);
        };
    }

    private void OnDisable()
    {
        onCloseAd -= (bool isClosed) =>
        {
            SetActiveAudioListener(isClosed);
        };
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    private void SetActiveAudioListener(bool isClosed)
    {
        if(isClosed)
            AudioListener.volume = 1;
    }

    public void ShowAd()
    {
        AudioListener.volume = 0;
        InterstitialAd.Show(onOpenAd, onCloseAd);
    }
}