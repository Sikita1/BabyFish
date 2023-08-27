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
    [SerializeField] private Training _training;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;
    [SerializeField] private Achiv _achiv;

    [SerializeField] private GameWinPanel _winPanel;

    //private YandexSDK _yandexSDK;

    private bool _isFocus;

    private void Awake()
    {
        //_yandexSDK = YandexSDK.Instance;
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _isFocus = true;
        
        Resume();

        _gameOverScreen.gameObject.SetActive(false);
        _gameWinScreen.gameObject.SetActive(false);
        _gamePauseScreen.gameObject.SetActive(false);

        //ADS();
        //ShowADS();
    }

    private void Update()
    {
        if (_isFocus == true
            && _winPanel.IsADS == false
            && (_training == null || _training.gameObject.activeSelf == false)
            && (_achiv == null || _achiv.gameObject.activeSelf == false))
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
    }

    private void OnApplicationFocus(bool focus)
    {
        _isFocus = focus;
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

    public void OnPause()
    {
        _gamePauseScreen.gameObject.SetActive(true);
    }

    //private bool IsRunAds()
    //{
    //    int[] numberScene = new int[] { 1, 3, 7, 11, 15, 19, 23, 27, 31, 34, 37, 41, 45, 48, 51, 55 };
    //    bool isState = false;

    //    for (int i = 0; i < numberScene.Length - 1; i++)
    //        if (SceneManager.GetActiveScene().buildIndex == numberScene[i])
    //            isState = true;

    //    return isState;
    //}

    //private void ShowADS()
    //{
    //    if (IsRunAds() == false)
    //        InterstitialAd.Show(
    //            onOpenCallback: OnOpenADS,
    //            onCloseCallback: OnCloseADS);
    //}

    //private void OnCloseADS(bool obj)
    //{
    //    _isADS = false;
    //}

    //private void OnOpenADS()
    //{
    //    OnPause();
    //    _isADS = true;
    //}

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
    }

    private void OnLoss()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _buttonPause.gameObject.SetActive(false);
    }
}
