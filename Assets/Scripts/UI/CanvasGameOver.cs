using UnityEngine;

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

    private bool _isFocus;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _isFocus = true;
        
        Resume();

        _gameOverScreen.gameObject.SetActive(false);
        _gameWinScreen.gameObject.SetActive(false);
        _gamePauseScreen.gameObject.SetActive(false);
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
