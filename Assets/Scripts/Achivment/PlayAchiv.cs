using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayAchiv : MonoBehaviour
{
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _image;

    [SerializeField] private AudioSource _audioSource;

    private IEnumerator _coroutine;

    private void Start()
    {
        _image.transform.localScale = new Vector3(0,0,0);
        _coroutine = OnClosePanel();
        StartCoroutine(OnOpenPanel());
        StartCoroutine(_coroutine);
    }

    public void OnPlayGame()
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
}
