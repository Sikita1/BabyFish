using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameWinPanel : MonoBehaviour
{
    [SerializeField] private Animator _animatorScreenWin;
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private TMP_Text _buttonNextLevelText;

    private const string _saveKey = "saveScene";

    public bool IsADS { get; private set; }

    private Animator _animator;

    private int _timeToADS;

    private void Start()
    {
        _buttonNextLevelText.text = $"Следующий уровень: {GetCurrentScene()}";
        _panelColor.StartOn();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Save();
        YandexGame.OpenFullAdEvent += OnOpenADS;
        YandexGame.CloseFullAdEvent += OnCloseADS;
        YandexGame.ErrorFullAdEvent += OnErrorADS;
    }


    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= OnOpenADS;
        YandexGame.CloseFullAdEvent -= OnCloseADS;
        YandexGame.ErrorFullAdEvent -= OnErrorADS;
    }

    public void NextLevelButtonClick()
    {
        _timeToADS = YandexGame.Instance.infoYG.fullscreenAdInterval - (int)YandexGame.timerShowAd;

        if (_timeToADS > 0)
        {
            _animatorScreenWin.SetTrigger("Fade");
            _animator.SetBool("Open", false);
            StartCoroutine(FadeComplete(GetCurrentScene()));
        }
        else
        {
#if UNITY_EDITOR == false
            ShowADS();
#endif
        }
    }

    private void OnErrorADS()
    {
        _animatorScreenWin.SetTrigger("Fade");
        _animator.SetBool("Open", false);
        StartCoroutine(FadeComplete(GetCurrentScene()));
    }

    private void ShowADS()
    {
        YandexGame.FullscreenShow();
    }

    private void OnCloseADS()
    {
        IsADS = false;
    }

    private void OnOpenADS()
    {
        IsADS = true;
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
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(times.Length);

        yield return wait;

        SceneManager.LoadScene(scene);
        gameObject.SetActive(false);
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
