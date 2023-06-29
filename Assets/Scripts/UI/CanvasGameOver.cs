using UnityEngine;

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

    private void OnWin()
    {
        _gameWinScreen.gameObject.SetActive(true);
        _buttonPause.gameObject.SetActive(false);
        Time.timeScale = 0f;
        //_slider.enabled = false;
        //_playerMover.StopPlayer();
        //_enemyMover.StopEnemy();
        //_spawner.StopSpawner();
    }

    private void OnLoss()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _buttonPause.gameObject.SetActive(false);
        Time.timeScale = 0f;
        //_slider.enabled = false;
        //_playerMover.StopPlayer();
        //_enemyMover.StopEnemy();
        //_spawner.StopSpawner();
    }
}
