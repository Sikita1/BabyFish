using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimeLevel : MonoBehaviour
{
    [SerializeField] private LevelFinisher _finisher;
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _step;

    private Coroutine _coroutine;

    private void Start()
    {
        _slider.maxValue = _finisher.MaxBonusValue;
    }

    private void OnEnable()
    {
        _player.BonusTaken += OnRaiseBonus;
    }

    private void OnDisable()
    {
        _player.BonusTaken -= OnRaiseBonus;
    }

    private void OnRaiseBonus(int stretch)
    {
        if (_coroutine != null)
            StopCoroutine(SlideDisplay(stretch));

        _coroutine = StartCoroutine(SlideDisplay(stretch));
    }

    private IEnumerator SlideDisplay(int target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _step * Time.deltaTime);
            yield return null;
        }
    }
}
