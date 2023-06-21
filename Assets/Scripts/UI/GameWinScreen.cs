using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinScreen : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _menuButton;

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(MenuButtonOnClick);
        _nextLevelButton.onClick.AddListener(NextLevelButtonClick);
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(MenuButtonOnClick);
        _nextLevelButton.onClick.RemoveListener(NextLevelButtonClick);
    }

    private void NextLevelButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void MenuButtonOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
