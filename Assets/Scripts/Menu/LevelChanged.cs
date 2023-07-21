using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanged : MonoBehaviour
{
    [SerializeField] private Animator _animatorPanel;

    private Animator _animator;

    private const string _saveKey = "saveScene";

    private void Start()
    {
        Time.timeScale = 1f;
        _animator = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        _animator.SetTrigger("Fade");
        
        StartCoroutine(FadeComplete(Scene()));
    }

    public void OpenMenu()
    {
        _animator.SetTrigger("Fade");
        _animatorPanel.SetBool("Open", false);
        StartCoroutine(FadeComplete(0));
    }

    public int GetCurrentScene() => Scene();

    private IEnumerator FadeComplete(int scene)
    {
        Time.timeScale = 1f;
        var times = _animator.GetCurrentAnimatorClipInfo(0);
        WaitForSeconds wait = new WaitForSeconds(times.Length);

        yield return wait;

        SceneManager.LoadScene(scene);
    }

    private int Scene()
    {
        var data = SaveManager.Load<SaveData.SceneController>(_saveKey);
        return data.CurrentScene;
    }
}
