using System;
using TMPro;
using UnityEngine;

public class ViewProgress : MonoBehaviour
{
    [SerializeField] private TMP_Text _textAwards;
    [SerializeField] private TMP_Text _textPearls;
    [SerializeField] private TMP_Text _textLevels;
    [SerializeField] private TMP_Text _textLocations;
    [SerializeField] private TMP_Text _textCharacters;
    [SerializeField] private TMP_Text _textProgressGame;
    [SerializeField] private TMP_Text _textLevelOnPanel;

    [SerializeField] private PearlsCount _pearls;
    [SerializeField] private LevelChanged _level;
    [SerializeField] private Score _scoreAward;
    [SerializeField] private ChangedScore _score;
    [SerializeField] private ProgressButton _button;

    private int _totalAwards = 57;
    private int _totalScenes = 60;
    private int _totalLocations = 12;
    private int _totalCharacteds = 5;
    private int _fullPercent = 100;

    private void Start()
    {
        ViewCurrentScene();
    }

    private void OnEnable()
    {
        _button.PanelOpening += OnGetCurrentStatistics;
    }

    private void OnDisable()
    {
        _button.PanelOpening -= OnGetCurrentStatistics;
    }

    public void ViewCurrentScene()
    {
        ShowText(_textLevelOnPanel, $"Текущий уровень: {_level.GetCurrentScene()}");
    }

    private void OnGetCurrentStatistics()
    {
        double overallProgress = Math.Round(GetOverallProgress(), 2);

        ShowText(_textCharacters, $"Открыто персонажей: {GetCurrentCharacter()}/{_totalCharacteds.ToString()}");
        ShowText(_textLocations, $"Открыто локаций: {GetCurrentLocation()}/{_totalLocations.ToString()}");
        ShowText(_textLevels, $"Открыто уровней: {_level.GetCurrentScene()}/{_totalScenes.ToString()}");
        ShowText(_textProgressGame, $"Всего пройдено: {overallProgress}/{_fullPercent.ToString()}");
        ShowText(_textAwards, $"Награды: {_score.GetNumberSprite()}/{_totalAwards.ToString()}");
        ShowText(_textPearls, $"Жемчуг: {_pearls.GetText()}");
    }

    private int GetCurrentLocation()
    {
        int[] locationMaps = new[] { 0, 2, 10, 14, 18, 26, 30, 34, 40, 44, 47, 57 };

        return GetNumberAchievement(locationMaps);
    }

    private int GetCurrentCharacter()
    {
        int[] numberCharacter = new[] { 0, 6, 22, 36, 53 };

        return GetNumberAchievement(numberCharacter);
    }

    private int GetNumberAchievement(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
            if (array[i] <= _level.GetCurrentScene() && _level.GetCurrentScene() <= array[i+1])
                return i + 1;

        return default;
    }

    private float GetOverallProgress() =>
        ((((float)_level.GetCurrentScene() + (float)_score.GetNumberSprite()) / ((float)_totalAwards + (float)_totalScenes)) * _fullPercent);

    private void ShowText(TMP_Text text, string stringText)
    {
        text.text = stringText;
    }
}
