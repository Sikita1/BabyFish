using UnityEngine;
using YG;

public class AwardAnimator : MonoBehaviour
{
    [SerializeField] private ChangedScore _score;
    [SerializeField] private GameObject _panel;
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private PSAnim _pSAnim;
    [SerializeField] private AudioSource _audio;

    public bool IsADS { get; private set; }

    private void Awake()
    {
        _panel.SetActive(false);
    }

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += OpenCallback;
        YandexGame.CloseFullAdEvent += CloseCallback;
    }

    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= OpenCallback;
        YandexGame.CloseFullAdEvent -= CloseCallback;
    }

    private void OnPanelOn()
    {
        _panel.SetActive(true);
        _panelColor.StartOn();
    }

    private void OnStartPanelOff()
    {
        _panelColor.StartOff();
    }

    private void OnPanelOff()
    {
        _panel.SetActive(false);

        YandexGame.FullscreenShow();
    }

    private void OpenCallback()
    {
        IsADS = true;
    }

    private void CloseCallback()
    {
        IsADS = false;
    }

    private void OnFinish()
    {
        _score.OnStartChangingIcon();
        _pSAnim.OnStartPS();
    }
}
