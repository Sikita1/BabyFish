using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _score.ScoreChanged += OnDisplayScore;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= OnDisplayScore;
    }

    private void OnDisplayScore(int score)
    {
        _text.text = $"{score}";
    }
}
