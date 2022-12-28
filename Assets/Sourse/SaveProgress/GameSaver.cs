using Newtonsoft.Json;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    public void Save(int levelNumber)
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif
        Save save = new Save(levelNumber);

        PlayerPrefs.SetString(nameof(Save), JsonConvert.SerializeObject(save));
        PlayerPrefs.Save();
    }
}