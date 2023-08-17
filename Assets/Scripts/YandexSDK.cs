using System;
using System.Collections;
using Agava.WebUtility;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YandexSDK : MonoBehaviour
{
    public static YandexSDK Instance = null;

    private bool _isAdRunning;
    private bool _isRewarded;
    private string _language;

    public string Language => _language;
    public bool IsInitialize { get; private set; }

    public event Action Initialized;
    public event Action ShowedInterstitianal;
    public event Action ShowedRewarded;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private IEnumerator Start()
    {
#if UNITY_EDITOR
        Initialized?.Invoke();
        IsInitialize = true;
        yield break;
#endif
        yield return YandexGamesSdk.Initialize(Initialize); 
    }

    private void Initialize()
    {
        Initialized?.Invoke();
        _language = YandexGamesSdk.Environment.i18n.lang;
        IsInitialize = true;
    }

    public void ShowInterstitial(Action onOpenCallback = null, Action onCloseCallback = null)
    {
        void onOpenAction()
        {
            onOpenCallback?.Invoke();
            MuteAudio(true);
            ShowedInterstitianal?.Invoke();
        }

        void onCloseAction(bool wasShown)
        {
            onCloseCallback?.Invoke();
            MuteAudio(false);
        }

#if UNITY_EDITOR
        onOpenAction();
        onCloseAction(true);
        return;
#endif
        InterstitialAd.Show(onOpenAction, onCloseAction);
    }

    public void ShowVideoAd(Action onRewardedCallback = null, Action onOpenCallback = null, Action onCloseCallback = null)
    {
        void onOpenAction()
        {
            StartCoroutine(CheckRewarded());

            onOpenCallback?.Invoke();
            MuteAudio(true);

            _isAdRunning = true;
        }

        void onCloseAction()
        {
            onCloseCallback?.Invoke();
            MuteAudio(false);

            _isAdRunning = false;
        }

        void onRewardedAction()
        {
            onRewardedCallback?.Invoke();

            _isRewarded = true;
        }

#if UNITY_EDITOR
        onOpenAction();
        onRewardedAction();
        onCloseAction();
        return;
#endif
        VideoAd.Show(onOpenAction, onRewardedAction, onCloseAction);
    }

    private IEnumerator CheckRewarded()
    {
        while (_isRewarded == false)
            yield return null;

        ShowedRewarded?.Invoke();
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        if (!_isAdRunning)
            MuteAudio(inBackground);
    }

    private void MuteAudio(bool value)
    {
        AudioListener.pause = value;
        AudioListener.volume = value ? 0f : 1f;
    }
}