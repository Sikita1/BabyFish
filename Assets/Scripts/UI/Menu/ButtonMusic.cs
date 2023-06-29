using UnityEngine.UI;
using UnityEngine;

public class ButtonMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Button _stateMusic;
    [SerializeField] private Sprite _musicOff;
    [SerializeField] private Sprite _musicOn;
    [SerializeField] private bool _isOnOffMusic;
    [SerializeField] private Slider _slider;

    private float _volume;

    private void Start()
    {
        _isOnOffMusic = true;
    }

    public void OnOffMusic()
    {
        if (_isOnOffMusic)
            DisableMusic();
        else
            EnableMusic();
    }

    public void SliderMusic()
    {
        _volume = _slider.value;
        _audio.volume = _volume;

        if (_volume == 0)
            _stateMusic.image.sprite = _musicOff;
        else
            _stateMusic.image.sprite = _musicOn;
    }

    private void DisableMusic()
    {
        _isOnOffMusic = false;
        _slider.value = 0;
        _audio.Pause();
        _stateMusic.image.sprite = _musicOff;
    }

    private void EnableMusic()
    {
        _isOnOffMusic = true;
        _audio.Play();
        _slider.value = 0.5f;
        _audio.volume = 0.5f;
        _stateMusic.image.sprite = _musicOn;
    }
}
