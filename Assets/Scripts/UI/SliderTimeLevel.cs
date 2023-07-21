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
    private int _countBonus;

    private const string _saveKey = "bonusCount";

    private void Start()
    {
        _countBonus = 0;
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

        _countBonus++;

        if (_countBonus == _finisher.MaxBonusValue)
            Save();
    }

    private IEnumerator SlideDisplay(int target)
    {
        float step = 0.01f;

        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, step);
            yield return null;
        }
    }

    private void Save()
    {
        int currentBonuses = SaveManager.Load<SaveData.Pearls>(_saveKey).Count;

        SaveManager.Save(_saveKey, GetSaveSnapshot(currentBonuses));
    }

    private SaveData.Pearls GetSaveSnapshot(int currentBonuses)
    {
        var data = new SaveData.Pearls()
        {
            Count = _countBonus + currentBonuses,
        };

        return data;
    }
}