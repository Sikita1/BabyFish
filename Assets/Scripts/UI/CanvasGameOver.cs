using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using System;

[RequireComponent(typeof(AudioSource))]
public class CanvasGameOver : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameWinScreen _gameWinScreen;
    [SerializeField] private GamePauseScreen _gamePauseScreen;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private SliderTimeLevel _slider;
    [SerializeField] private LevelFinisher _finisher;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;
    [SerializeField] private ButtonPause _buttonPause;

    [SerializeField] private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        _gameOverScreen.gameObject.SetActive(false);
        _gameWinScreen.gameObject.SetActive(false);
        _gamePauseScreen.gameObject.SetActive(false);
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
        if(IsRunAds() == false)
            InterstitialAd.Show(
                onOpenCallback: OpenCallback,
                onCloseCallback: CloseCallback);
    }

    private void OpenCallback()
    {
        _audio.Pause();
        Time.timeScale = 0f;
    }

    private void CloseCallback(bool status)
    {
        _audio.Play();
        Time.timeScale = 1f;
    }

    private void OnWin()
    {
        _gameWinScreen.gameObject.SetActive(true);
        _buttonPause.gameObject.SetActive(false);
        Time.timeScale = 0f;

        ShowADS();
    }

    private void OnLoss()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _buttonPause.gameObject.SetActive(false);
        Time.timeScale = 0f;

        ShowADS();
    }
}
