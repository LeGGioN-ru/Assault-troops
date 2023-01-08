using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelCloseButton : MonoBehaviour
{
    [SerializeField] private int _nextScene;

    public void OnNextLevel()
    {
        SceneManager.LoadScene(_nextScene);
    }

    public void OnRestatrLevel()
    {
        SceneManager.LoadScene(_nextScene - 1);
    }
}