using System.Collections;
using System.Collections.Generic;
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

    private int _location = 0;
    private int _character = 0;

    private void Start()
    {
        ShowText(_textPearls, $"������: {_pearls.GetText()}");
        ShowText(_textLevels, $"������� �������: {_level.GetCurrentScene()}/60");
        ShowText(_textLevelOnPanel, $"������� �������: {_level.GetCurrentScene()}");
        ShowText(_textLocations, $"������� �������: {GetCurrentLocation()}/12");
        ShowText(_textCharacters, $"������� ����������: {GetCurrentCharacter()}/5");
    }

    private void OnEnable()
    {
        _button.PanelOpening += OnGetNumberSprite;
    }

    private void OnDisable()
    {
        _button.PanelOpening -= OnGetNumberSprite;
    }

    private void OnGetNumberSprite()
    {
        ShowText(_textAwards, $"�������: {_score.GetNumberSprite()}/57");
    }

    private int GetCurrentLocation()
    {
        //_location = GetnumberAchievement(0, 3, 1);
        //_location = GetnumberAchievement(3, 11, 2);
        //_location = GetnumberAchievement(11, 15, 3);
        //_location = GetnumberAchievement(15, 24, 4);
        //_location = GetnumberAchievement(24, 28, 5);
        //_location = GetnumberAchievement(28, 32, 6);
        //_location = GetnumberAchievement(32, 40, 7);
        //_location = GetnumberAchievement(40, 44, 8);
        //_location = GetnumberAchievement(44, 49, 9);
        //_location = GetnumberAchievement(49, 59, 10);
        //_location = GetnumberAchievement(59, 64, 11);
        //_location = GetnumberAchievement(64, 69, 12);

        if (_level.GetCurrentScene() >= 0 && _level.GetCurrentScene() < 3)
            _location = 1;
        else if (_level.GetCurrentScene() >= 3 && _level.GetCurrentScene() < 11)
            _location = 2;
        else if (_level.GetCurrentScene() >= 11 && _level.GetCurrentScene() < 19)
            _location = 3;
        else if (_level.GetCurrentScene() >= 19 && _level.GetCurrentScene() < 27)
            _location = 4;
        else if (_level.GetCurrentScene() >= 27 && _level.GetCurrentScene() < 34)
            _location = 5;
        else if (_level.GetCurrentScene() >= 34 && _level.GetCurrentScene() < 41)
            _location = 6;
        else if (_level.GetCurrentScene() >= 41 && _level.GetCurrentScene() < 48)
            _location = 7;
        else if (_level.GetCurrentScene() >= 48 && _level.GetCurrentScene() < 54)
            _location = 8;
        else if (_level.GetCurrentScene() >= 54 && _level.GetCurrentScene() < 60)
            _location = 9;
        else if (_level.GetCurrentScene() >= 60 && _level.GetCurrentScene() < 67)
            _location = 10;
        else if (_level.GetCurrentScene() >= 67 && _level.GetCurrentScene() < 73)
            _location = 11;
        else if (_level.GetCurrentScene() >= 73)
            _location = 12;

        return _location;
    }

    private int GetCurrentCharacter()
    {
        if (_level.GetCurrentScene() >= 0 && _level.GetCurrentScene() < 7)
            _character = 1;
        else if (_level.GetCurrentScene() >= 7 && _level.GetCurrentScene() < 19)
            _character = 2;
        else if (_level.GetCurrentScene() >= 19 && _level.GetCurrentScene() < 36)
            _character = 3;
        else if (_level.GetCurrentScene() >= 36 && _level.GetCurrentScene() < 54)
            _character = 4;
        else if (_level.GetCurrentScene() >= 54 && _level.GetCurrentScene() < 74)
            _character = 5;

        //_character = GetnumberAchievement(0, 7, 1);
        //_character = GetnumberAchievement(7, 19, 2);
        //_character = GetnumberAchievement(19, 36, 3);
        //_character = GetnumberAchievement(36, 54, 4);
        //_character = GetnumberAchievement(54, 74, 5);

        return _character;
    }

    private int GetnumberAchievement(int openingScene, int closingScene, int numberAchievement)
    {
        if (_level.GetCurrentScene() >= openingScene && _level.GetCurrentScene() < closingScene)
            return numberAchievement;
        else
            return 0;
    }

    private void ShowText(TMP_Text text, string stringText)
    {
        text.text = stringText;
    }
}
