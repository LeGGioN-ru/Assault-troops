using Newtonsoft.Json;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private GameObject _trainingPanel;

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

        LoadTraining(save);
    }

    private void LoadTraining(Save save)
    {
        if(save.IsShowTrainingFirstLevel == false)
        {
            _trainingPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}