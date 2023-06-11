using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderTimeLevel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    //[SerializeField] private int _fullPath;

    public event UnityAction EndLevel;

    private Coroutine _coroutine;
    private float _delay = 0.002f;

    //private void Start()
    //{
    //    _slider.maxValue = _fullPath;
    //}

    private void OnEnable()
    {
        _player.GoToWay += OnRaiseCrystal;
    }

    private void OnDisable()
    {
        _player.GoToWay -= OnRaiseCrystal;
    }

    private void OnRaiseCrystal(int stretch)
    {
        if (_coroutine != null)
            StopCoroutine(SlideDisplay(stretch));

        _coroutine = StartCoroutine(SlideDisplay(stretch));

        if (_slider.value == _slider.maxValue)
            EndGame();
    }

    public void EndGame()
    {
        EndLevel?.Invoke();
    }

    private IEnumerator SlideDisplay(int stretch)
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_slider.value != stretch)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, stretch, 1f);
            yield return wait;
        }
    }
}
