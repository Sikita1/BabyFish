using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelOver : MonoBehaviour
{
    [SerializeField] private PanelColor _panel;
    [SerializeField] private Animator _animatorBlackPanel;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _panel.StartOn();
    }

    public void OnScreenLoseOpen()
    {
        _animator.SetBool("Open", true);
    }

    public void OnMenuButtonClick()
    {
        ButtonClick(0);
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1f;
        ButtonClick(SceneManager.GetActiveScene().buildIndex);
    }

    private void ButtonClick(int scene)
    {
        _animatorBlackPanel.SetTrigger("Fade");
        _animator.SetBool("Open", false);
        StartCoroutine(DelayOpenScene(scene));
    }

    private IEnumerator DelayOpenScene(int scene)
    {
        var times = _animatorBlackPanel.GetCurrentAnimatorClipInfo(0);
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(times.Length + 0.1f);

        yield return wait;

        SceneManager.LoadScene(scene);
    }
}
