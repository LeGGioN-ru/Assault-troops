using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
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
        InterstitialAd.Show();
    }
}