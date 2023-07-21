using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinPanel : MonoBehaviour
{
    [SerializeField] private Animator _animatorScreenWin;
    [SerializeField] private PanelColor _panelColor;

    private const string _saveKey = "saveScene";
    private Animator _animator;

    private void Start()
    {
        _panelColor.StartOn();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Save();
    }

    public int GetCurrentScene() => SceneManager.GetActiveScene().buildIndex + 1;

    public void NextLevelButtonClick()
    {
        _animatorScreenWin.SetTrigger("Fade");
        _animator.SetBool("Open", false);
        StartCoroutine(FadeComplete(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void OnPanelOpen()
    {
        _animator.SetBool("Open", true);
    }

    private void Save()
    {
        SaveManager.Save(_saveKey, GetSaveScene());
    }

    private IEnumerator FadeComplete(int scene)
    {
        Time.timeScale = 1f;
        var times = _animatorScreenWin.GetCurrentAnimatorClipInfo(0);
        WaitForSeconds wait = new WaitForSeconds(times.Length);

        yield return wait;

        SceneManager.LoadScene(scene);
    }

    private SaveData.SceneController GetSaveScene()
    {
        var data = new SaveData.SceneController()
        {
            CurrentScene = SceneManager.GetActiveScene().buildIndex + 1,
        };

        return data;
    }
}
