using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanged : MonoBehaviour
{
    private Animator _animator;

    private const string _saveKey = "saveScene";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        _animator.SetTrigger("Fade");
    }

    public void OnFadeComplete()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(Scene());
    }

    public void OpenMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private int Scene()
    {
        var data = SaveManager.Load<SaveData.SceneController>(_saveKey);
        return data.CurrentScene;
    }
}
