using System;
using System.Collections;
using UnityEngine;
using Agava.YandexGames;

public class AwardAnimator : MonoBehaviour
{
    [SerializeField] private ChangedScore _score;
    [SerializeField] private GameObject _panel;
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private PSAnim _pSAnim;
    [SerializeField] private AudioSource _audio;

    private void Awake()
    {
        StartCoroutine(SDKInicialition());
        _panel.SetActive(false);
    }

    private IEnumerator SDKInicialition()
    {
#if !UNITY_EDITOR && UNITY_WEBGL 

        yield return YandexGamesSdk.Initialize();

#endif
        yield break;
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

        InterstitialAd.Show(
                onOpenCallback: OpenCallback,
                onCloseCallback: CloseCallback);
    }

    private void OpenCallback()
    {
        _audio.Pause();
    }

    private void CloseCallback(bool status)
    {
        _audio.Play();
    }

    private void OnFinish()
    {
        _score.OnStartChangingIcon();
        _pSAnim.OnStartPS();
    }
}
