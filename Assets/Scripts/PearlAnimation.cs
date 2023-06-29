using UnityEngine;
using DG.Tweening;
using System;

public class PearlAnimation : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public void Anim(Transform transform, TweenCallback callBack)
    {
        transform.DOMove(_target.position, 2).OnComplete(callBack);
        //transform.DOScale
    }
}
