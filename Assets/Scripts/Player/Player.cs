using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> BonusTaken;
    public event UnityAction Died;

    private Animator _animator;
    private int _stretchTrack = 0;

    private const string _saveKey = "saveScene";

    private void Start()
    {
        Save();
        HealthChanged?.Invoke(_health);
        BonusTaken?.Invoke(_stretchTrack);

        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        _animator.SetTrigger("Clash");

        if (_health <= 0)
            Die();
    }

    public void RaiseBonus(int stretch)
    {
        _stretchTrack += stretch;
        BonusTaken?.Invoke(_stretchTrack);
    }

    public void SpeedUp()
    {
        _animator.speed = 5;
    }

    public void SpeedNormal()
    {
        _animator.speed = 2;
    }

    public void Die()
    {
        Died?.Invoke();
    }

    private void Save()
    {
        SaveManager.Save(_saveKey, GetSaveScene());
    }

    private SaveData.SceneController GetSaveScene()
    {
        var data = new SaveData.SceneController()
        {
            CurrentScene = SceneManager.GetActiveScene().buildIndex,
        };

        return data;
    }
}
