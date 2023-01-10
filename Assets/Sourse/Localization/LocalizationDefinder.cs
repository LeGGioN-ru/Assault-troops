using Agava.YandexGames;
using Lean.Localization;
using System.Collections;
using UnityEngine;

public class LocalizationDefinder : MonoBehaviour
{
    [SerializeField] private LoadScreen _loadScreen;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        _loadScreen.gameObject.SetActive(false);
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        LeanLocalization.SetCurrentLanguageAll(YandexGamesSdk.Environment.i18n.lang);
        _loadScreen.gameObject.SetActive(false);
    }
}
