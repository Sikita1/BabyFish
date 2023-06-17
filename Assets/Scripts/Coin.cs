using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _award;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.RaiseBonus(_award);

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
