using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonGoGame : MonoBehaviour
{
    [SerializeField] private Button _loadLevel;

    private void OnEnable()
    {
        _loadLevel.onClick.AddListener(DownloadLevel);
    }

    private void OnDisable()
    {
        _loadLevel.onClick.RemoveListener(DownloadLevel);
    }

    private void DownloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
