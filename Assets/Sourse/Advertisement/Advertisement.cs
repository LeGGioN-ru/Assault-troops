using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
    [SerializeField] private AudioListener _listener;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    public void ShowAd()
    {
        AudioListener.volume = 0;
        InterstitialAd.Show();
    }
}