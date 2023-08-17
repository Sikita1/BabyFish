using UnityEngine.UI;
using UnityEngine;

public class ButtonMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Button _stateMusic;
    [SerializeField] private Sprite _musicOff;
    [SerializeField] private Sprite _musicOn;
    [SerializeField] private Slider _slider;

    private const string _saveKey = "musicState";

    private bool _isOnOffMusic;
    private float _volume;

    private float _defaultSound = 0.5f;

    private void Awake()
    {
        Load();
        ShowAudioStatus();
    }

    public void OnOffMusic()
    {
        if (_isOnOffMusic)
        {
            DisableMusic();
            Save();
        }
        else
        {
            EnableMusic();
            Save();
        }
    }

    public void SliderMusic()
    {
        _volume = _slider.value;
        _audio.volume = _volume;

        ShowAudioStatus();

        Save();
    }

    private void DisableMusic()
    {
        _isOnOffMusic = false;
        _slider.value = 0;
        _audio.Pause();

        ShowAudioStatus();

        Save();
    }

    private void EnableMusic()
    {
        _isOnOffMusic = true;
        _audio.Play();
        _slider.value = _defaultSound;
        _audio.volume = _defaultSound;

        ShowAudioStatus();

        Save();
    }

    private void ShowAudioStatus()
    {
        if (_volume == 0)
            _stateMusic.image.sprite = _musicOff;
        else
            _stateMusic.image.sprite = _musicOn;
    }

    private void Save()
    {
        SaveManager.Save(_saveKey, GetSaveSnapshot());
    }

    private SaveData.MusicController GetSaveSnapshot()
    {
        var data = new SaveData.MusicController()
        {
            IsOnMusic = _isOnOffMusic,
            VolumeMusic = _audio.volume
        };

        return data;
    }

    private void Load()
    {
        var data = SaveManager.Load<SaveData.MusicController>(_saveKey);

        _isOnOffMusic = data.IsOnMusic;
        _audio.volume = data.VolumeMusic;
        _slider.value = data.VolumeMusic;
    }
}
