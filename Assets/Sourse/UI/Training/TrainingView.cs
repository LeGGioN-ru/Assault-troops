using UnityEngine;

public class TrainingView : MonoBehaviour
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private GameSaver _saver;

    public void OnClosePanel()
    {
        Time.timeScale = 1;

        _saver.Save(_currentLevel, true);
        gameObject.SetActive(false);
    }
}