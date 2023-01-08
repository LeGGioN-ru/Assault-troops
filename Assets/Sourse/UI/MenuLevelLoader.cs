using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelLoader : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void OnLoadLevel()
    {
        string jsonSave = PlayerPrefs.GetString(nameof(Save));

        if (string.IsNullOrEmpty(jsonSave))
        {
            SceneManager.LoadScene(1);
            return;
        }

        Save save = JsonConvert.DeserializeObject<Save>(jsonSave);

        SceneManager.LoadScene(save.Level);
    }
}