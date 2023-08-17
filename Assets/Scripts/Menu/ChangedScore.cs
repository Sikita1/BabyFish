using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangedScore : MonoBehaviour
{
    [SerializeField] private SpawnGarbages _spawn;
    [SerializeField] private Animator _animator;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image;
    [SerializeField] private Score _score;
    [SerializeField] private float _lerpDuraction;
    [SerializeField] private AudioSource _audio;

    private void Start()
    {
        OnStartChangingIcon();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
            PauseGame();
        else
            PlayGame();
    }

    private void OnEnable()
    {
        _spawn.ChangedAward += ChangeSprite;
    }

    private void OnDisable()
    {
        _spawn.ChangedAward -= ChangeSprite;
    }

    public float GetLerpDuraction() => _lerpDuraction;

    public int GetNumberSprite() => _score.GetScore() / _spawn.GetNumberPoints();

    public void OnStartChangingIcon()
    {
        int numberSprite = GetNumberSprite();

        if (GetNumberSprite() == 0)
            _image.sprite = _sprites[0];

        if (numberSprite >= _sprites.Length)
            numberSprite = _sprites.Length - 1;

        StartCoroutine(Filling(0, 1, _lerpDuraction, numberSprite));
    }

    private void ChangeSprite()
    {
        _animator.SetBool("isShow", true);
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, int numberSprite)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            _image.sprite = _sprites[numberSprite];
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }
         
        _animator.SetBool("isShow", false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        _audio.Pause();
    }

    private void PlayGame()
    {
        Time.timeScale = 1f;
        _audio.Play();
    }
}
