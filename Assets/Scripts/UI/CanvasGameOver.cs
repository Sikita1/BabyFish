using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using System.Collections;

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

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        Debug.Log("1");

        _gameOverScreen.gameObject.SetActive(false);
        _gameWinScreen.gameObject.SetActive(false);
        _gamePauseScreen.gameObject.SetActive(false);

        ShowADS();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            OpenCallback();
        }
        else
        {
            CloseCallback(true);

            if (_gameOverScreen.gameObject.activeSelf == true ||
                _gameWinScreen.gameObject.activeSelf == true ||
                _gamePauseScreen.gameObject.activeSelf == true)
                Time.timeScale = 0f;
        }
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

    private IEnumerator ShowADS()
    {
        yield return new WaitForSecondsRealtime(1);

        Debug.Log("2");

        if (IsRunAds() == false)
            InterstitialAd.Show(
                onOpenCallback: OpenCallback,
                onCloseCallback: CloseCallback);
    }

    private void OpenCallback()
    {
        Time.timeScale = 0f;
        _audio.Pause();
        Debug.Log("3");
    }

    private void CloseCallback(bool status)
    {
        Time.timeScale = 1f;
        Debug.Log("4");
        _audio.Play();
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
