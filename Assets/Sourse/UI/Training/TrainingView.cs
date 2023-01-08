using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingView : MonoBehaviour
{
    public void OnClosePanel()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}