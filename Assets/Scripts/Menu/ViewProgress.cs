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
        ShowText(_textPearls, $"������: {_pearls.GetText()}");
        ShowText(_textLocations, $"������� �������: {GetCurrentLocation()}/{_totalLocations.ToString()}");
        ShowText(_textCharacters, $"������� ����������: {GetCurrentCharacter()}/{_totalCharacteds.ToString()}");
    }

    private void OnEnable()
    {
        _button.PanelOpening += OnGetNumberSprite;
        _button.PanelOpening += OnGetCurrentPercentPassRate;
        _button.PanelOpening += OnGetCurrentScene;
    }

    private void OnDisable()
    {
        _button.PanelOpening -= OnGetNumberSprite;
        _button.PanelOpening -= OnGetCurrentPercentPassRate;
        _button.PanelOpening -= OnGetCurrentScene;
    }

    public void ViewCurrentScene()
    {
        ShowText(_textLevelOnPanel, $"������� �������: {_level.GetCurrentScene()}");
    }

    private void OnGetCurrentScene()
    {
        ShowText(_textLevels, $"������� �������: {_level.GetCurrentScene()}/{_totalScenes.ToString()}");
    }

    private void OnGetCurrentPercentPassRate()
    {
        double overallProgress = Math.Round(GetOverallProgress(), 2);

        ShowText(_textProgressGame, $"����� ��������: {overallProgress}/{_fullPercent.ToString()}");
    }

    private void OnGetNumberSprite()
    {
        ShowText(_textAwards, $"�������: {_score.GetNumberSprite()}/{_totalAwards.ToString()}");
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
