using UnityEngine;

public class Pearl : MonoBehaviour
{
    [SerializeField] private int _award;

    private PearlAnimation _coinAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _coinAnimation.Anim(transform, Die);
            player.RaiseBonus(_award);
        }
        else
        {
            Die();
        }
    }

    public void SetAnimation(PearlAnimation pearlAnimation)
    {
        _coinAnimation = pearlAnimation;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
