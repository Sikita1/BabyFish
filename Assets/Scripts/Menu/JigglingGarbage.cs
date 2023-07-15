using UnityEngine;
using DG.Tweening;

public class JigglingGarbage : MonoBehaviour
{
    private Tween _tweenVertical;
    private float _upperBoundary = 0.2f;
    private float _speed = 2f;

    private void Start()
    {
        _tweenVertical = transform.DOMoveY(transform.position.y + _upperBoundary, _speed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        KillTween(_tweenVertical);
    }

    private void KillTween(Tween tween)
    {
        tween.Kill();
    }
}
