using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class CanvasGameOver : MonoBehaviour
{
    [SerializeField] private GamePauseScreen _gamePauseScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameWinScreen _gameWinScreen;
    [SerializeField] private ButtonPause _buttonPause;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private SliderTimeLevel _slider;
    [SerializeField] private LevelFinisher _finisher;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;
    [SerializeField] private Training _training; 

    //private YandexSDK _yandexSDK;

    private bool _isADS;
    private bool _isFocus;

    private Coroutine _coroutine;

    private void Awake()
    {
        //_yandexSDK = YandexSDK.Instance;
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Resume();

        _gameOverScreen.gameObject.SetActive(false);
        _gameWinScreen.gameObject.SetActive(false);
        _gamePauseScreen.gameObject.SetActive(false);

        //ADS();
        ShowADS();
    }

    private void Update()
    {
        if (_isFocus == true && _isADS == false && _training.gameObject.activeSelf == false)
        {
            Resume();

            if (_gameOverScreen.gameObject.activeSelf == true ||
                _gameWinScreen.gameObject.activeSelf == true ||
                _gamePauseScreen.gameObject.activeSelf == true)
                Time.timeScale = 0f;
        }
        else
        {
            Pause();
        }

        Debug.Log($"_isFocus{_isFocus}");
        Debug.Log($"_isADS{_isADS}");
        Debug.Log($"_training{_training.gameObject.activeSelf}");

        //if (_isFocus == false || _isADS == true || _training.gameObject.activeSelf == true)
        //{
        //    Pause();
        //}
        //else
        //{
        //    Resume();

        //    if (_gameOverScreen.gameObject.activeSelf == true ||
        //        _gameWinScreen.gameObject.activeSelf == true ||
        //        _gamePauseScreen.gameObject.activeSelf == true)
        //        Time.timeScale = 0f;
        //}
    }

    private void OnApplicationFocus(bool focus)
    {
        //if (focus == false || _isADS == true || _training.gameObject.activeSelf == true)
        //{
        //    Pause();
        //}
        //else
        //{
        //    Resume();

        //    if (_gameOverScreen.gameObject.activeSelf == true ||
        //        _gameWinScreen.gameObject.activeSelf == true ||
        //        _gamePauseScreen.gameObject.activeSelf == true)
        //        Time.timeScale = 0f;
        //}

        if (focus == false)
            _isFocus = false;
        else
            _isFocus = true;
    }

    private void OnEnable()
    {
        _finisher.Finished += OnWin;
        _player.Died += OnLoss;
    }

    private void OnDisable()
    {
        _finisher.Finished -= OnWin;
        _player.Died -= OnLoss;
    }

    public void FocusTrue() => _isFocus = true;

    public void OnPause()
    {
        _gamePauseScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private bool IsRunAds()
    {
        int[] numberScene = new int[] { 1, 3, 5, 7, 9, 11 };
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
        _isADS = false;
    }

    private void OnOpenADS()
    {
        _isADS = true; 
    }

    //private void ADS()
    //{
    //    _yandexSDK.ShowInterstitial(OpenCallback, CloseCallback);
    //}

    private void Pause()
    {
        _audio.Pause();
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        _audio.UnPause();
    }

    private void OnWin()
    {
        _gameWinScreen.gameObject.SetActive(true);
        _buttonPause.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void OnLoss()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _buttonPause.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
}
