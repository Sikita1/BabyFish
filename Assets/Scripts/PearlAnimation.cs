using DG.Tweening;
using UnityEngine;

public class PearlAnimation : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float duraction = 2f;

    public void Anim(Transform transform, TweenCallback callBack)
    {
        transform
            .DOMove(_target.position, duraction)
            .SetUpdate(true)
            .OnComplete(callBack);
    }
}
