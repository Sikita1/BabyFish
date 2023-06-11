using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinScreen : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(NextLevelButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(NextLevelButtonClick);
    }

    private void NextLevelButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
