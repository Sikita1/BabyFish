using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;

public class GameWinPanel : MonoBehaviour
{
    [SerializeField] private Animator _animatorScreenWin;
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private TMP_Text _buttonNextLevelText;

    private const string _saveKey = "saveScene";

    public bool IsADS { get; private set; }

    private Animator _animator;
    private bool _isADSShow;

    private void Start()
    {
        _isADSShow = true;
        _buttonNextLevelText.text = $"Следующий уровень: {GetCurrentScene()}";
        _panelColor.StartOn();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log($"{_isADSShow}");
    }

    private void OnEnable()
    {
        Save();
    }

    public void NextLevelButtonClick()
    {
        if (_isADSShow == true)
        {
            ShowADS();
        }
        else
        {
            _animatorScreenWin.SetTrigger("Fade");
            _animator.SetBool("Open", false);
            StartCoroutine(FadeComplete(GetCurrentScene()));
        }

    }

    private bool IsRunAds()
    {
        int[] numberScene = new int[] { 1, 3, 7, 11, 15, 19, 23, 27, 31, 34, 37, 41, 45, 48, 51, 55 };
        bool isState = false;

        for (int i = 0; i < numberScene.Length - 1; i++)
            if (SceneManager.GetActiveScene().buildIndex == numberScene[i])
                isState = true;

        return isState;
    }

    private void ShowADS()
    {
        if (IsRunAds() == false)
            InterstitialAd.Show(
                onOpenCallback: OnOpenADS,
                onCloseCallback: OnCloseADS);
    }

    private void OnCloseADS(bool obj)
    {
        _isADSShow = false;
        IsADS = false;
    }

    private void OnOpenADS()
    {
        //_isADSShow = true;
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
