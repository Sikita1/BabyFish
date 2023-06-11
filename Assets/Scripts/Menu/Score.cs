using System;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    private int _value = 0;

    private void Start()
    {
        ScoreChanged?.Invoke(_value);
    }

    public int GetScore() => _value;

    public void ScoreUp(int value)
    {
        _value += value;
        ScoreChanged?.Invoke(_value);
    }
}
