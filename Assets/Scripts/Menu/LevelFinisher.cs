using UnityEngine;
using UnityEngine.Events;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _maxBonusValue;

    public event UnityAction Finished;

    public int MaxBonusValue => _maxBonusValue; 

    private void OnEnable()
    {
        _player.BonusTaken += OnBonusTaken;
    }

    private void OnDisable()
    {
        _player.BonusTaken -= OnBonusTaken;
    }

    private void OnBonusTaken(int bonusValue)
    {
        if (bonusValue == _maxBonusValue)
            EndGame();
    }

    public void EndGame()
    {
        Finished?.Invoke();
    }
}
