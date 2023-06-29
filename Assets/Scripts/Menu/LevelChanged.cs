using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanged : MonoBehaviour
{
    [SerializeField] private int _levelToLoad;

    private Animator _animator;

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
        SceneManager.LoadScene(_levelToLoad);
    }
}
