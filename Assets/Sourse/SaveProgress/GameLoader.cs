using Newtonsoft.Json;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    private void Start()
    {
        LoadSave(PlayerPrefs.GetString(nameof(Save)));
    }

    private void LoadSave(string jsonSave)
    {
        if (string.IsNullOrEmpty(jsonSave))
        {
            return;
        }

        Save save = JsonConvert.DeserializeObject<Save>(jsonSave);
        Debug.Log(save.Level);
    }
}