using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> BonusTaken;
    public event UnityAction Died;

    private Animator _animator;
    private int _stretchTrack = 0;

    private void Start()
    {
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

        //_animator.SetTrigger("");
    }

    public void SpeedUp()
    {
        _animator.speed = 5;
    }

    public void SpeedNormal()
    {
        _animator.speed = 1;
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
