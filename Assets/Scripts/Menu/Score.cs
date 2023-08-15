using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private const string _saveKey = "mainSaves";

    public event Action<int> ScoreChanged;

    private int _value;

    private void Start()
    {
        Load();
        ScoreChanged?.Invoke(_value);
    }

    public void ResetInvoice()
    {
        _value = 0;
        ScoreChanged?.Invoke(_value);
        Save();
    }

    public int GetScore() => _value;

    public void ScoreUp(int value)
    {
        _value += value;
        ScoreChanged?.Invoke(_value);
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<SaveData.PlayerScore>(_saveKey);

        _value = data.Score;
    }

    private void Save()
    {
        SaveManager.Save(_saveKey, GetSaveSnapshot());
    }

    private SaveData.PlayerScore GetSaveSnapshot()
    {
        var data = new SaveData.PlayerScore()
        {
            Score = _value,
        };

        return data;
    }
}
