using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PSAnim : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private GameObject _upperLimit;
    [SerializeField] private GameObject _lowerLimit;
    [SerializeField] private ChangedScore _changedScore;

    public void OnStartPS()
    {
        _particle.transform.position = _lowerLimit.transform.position;
        _particle.Play();
        _audio.Play();
        transform.DOMoveY(_upperLimit.transform.position.y, _changedScore.GetLerpDuraction())
                 .SetEase(Ease.Linear)
                 .OnComplete(SystemShutdown);
    }

    private void SystemShutdown()
    {
        _particle.Stop();
    }
}
