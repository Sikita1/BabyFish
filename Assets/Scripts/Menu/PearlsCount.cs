using UnityEngine;
using TMPro;
using System;

public class PearlsCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private const string _saveKey = "bonusCount";

    private int _currentNumber;

    private void Start()
    {
        CalculateDrawBonusCount();
        _text.text = _currentNumber.ToString();
    }

    public string GetText() => _currentNumber.ToString();

    private int Load()
    {
        var data = SaveManager.Load<SaveData.Pearls>(_saveKey);
        return data.Count;
    }

    private void CalculateDrawBonusCount()
    {
        _currentNumber = Load();
    }
}
