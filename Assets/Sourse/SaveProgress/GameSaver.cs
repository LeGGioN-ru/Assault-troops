using Newtonsoft.Json;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    public void Save(int levelNumber, bool showTrainigFirstLevel)
    {
//#if !UNITY_WEBGL || UNITY_EDITOR
//       return;
//#endif
        Save save = new Save(levelNumber, showTrainigFirstLevel);

        PlayerPrefs.SetString(nameof(Save), JsonConvert.SerializeObject(save));
        PlayerPrefs.Save();
    }
}