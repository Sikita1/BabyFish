using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAchiv : MonoBehaviour
{
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _image;

    [SerializeField] private AudioSource _audioSource;

    IEnumerator _coroutine;

    private void Start()
    {
        _image.transform.localScale = new Vector3(0,0,0);
        StartCoroutine(OnStopGame());
        _coroutine = OnClosePanel();
        StartCoroutine(OnOpenPanel());
        StartCoroutine(_coroutine);
    }

    public void OnStartGame()
    {
        Time.timeScale = 1f;
    }

    public void OnStartAnim()
    {
        _animator.SetBool("Open", true);
    }

    private IEnumerator OnClosePanel()
    {
        yield return new WaitForSecondsRealtime(3f);

        _animator.SetBool("Open", false);
        _panelColor.StartOff();
    }

    private IEnumerator OnOpenPanel()
    {
        yield return new WaitForSecondsRealtime(1f);

        _audioSource.Play();
        _animator = GetComponent<Animator>();
        _image.transform.localScale = new Vector3(1, 1, 1);
        _panelColor.StartOn();
    }

    private IEnumerator OnStopGame()
    {
        yield return new WaitForSeconds(0.1f);

        Time.timeScale = 0f;
    }
}
