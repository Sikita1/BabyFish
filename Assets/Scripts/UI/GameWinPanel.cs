using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinPanel : MonoBehaviour
{
    [SerializeField] private Animator _animatorScreenWin;
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private TMP_Text _buttonNextLevelText;

    private const string _saveKey = "saveScene";
    private Animator _animator;

    private void Start()
    {
        _buttonNextLevelText.text = $"Следующий уровень: {GetCurrentScene()}";
        _panelColor.StartOn();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Save();
    }

    public void NextLevelButtonClick()
    {
        _animatorScreenWin.SetTrigger("Fade");
        _animator.SetBool("Open", false);
        StartCoroutine(FadeComplete(GetCurrentScene()));
    }

    public void OnPanelOpen()
    {
        _animator.SetBool("Open", true);
    }

    private int GetCurrentScene() => SceneManager.GetActiveScene().buildIndex + 1;

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
            CurrentScene = GetCurrentScene(),
        };

        return data;
    }
}
