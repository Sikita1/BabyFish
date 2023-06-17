using UnityEngine;

public class CanvasGameOver : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameWinScreen _gameWinScreen;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private SliderTimeLevel _slider;
    [SerializeField] private LevelFinisher _finisher;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;

    private void Start()
    {
        _gameOverScreen.gameObject.SetActive(false);
        _gameWinScreen.gameObject.SetActive(false);
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

    private void OnWin()
    {
        _gameWinScreen.gameObject.SetActive(true);
        _slider.enabled = false;
        _playerMover.StopPlayer();
        _enemyMover.StopEnemy();
        _spawner.StopSpawner();
    }

    private void OnLoss()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _slider.enabled = false;
        _playerMover.StopPlayer();
        _enemyMover.StopEnemy();
        _spawner.StopSpawner();
    }
}
