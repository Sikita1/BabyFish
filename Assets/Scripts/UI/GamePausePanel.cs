using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Animator))]
public class GamePausePanel : MonoBehaviour
{
    [SerializeField] private Animator _animatorPanel;
    [SerializeField] private PanelColor _panelColor;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _panelColor.StartOn();
    }

    public void OnPanelOpen()
    {
        _animator.SetBool("Open", true);
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1f;
        ButtonClick(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuButtonClick()
    {
        ButtonClick(0);
    }

    public void OnContinueButtonClick()
    {
        Time.timeScale = 1f;
        _panelColor.StartOff();
        _animator.SetBool("Open", false);
        //_panelColor.gameObject.SetActive(false);
    }

    private void ButtonClick(int scene)
    {
        _animatorPanel.SetTrigger("Fade");
        _animator.SetBool("Open", false);
        StartCoroutine(DelayOpenScene(scene));
    }

    private IEnumerator DelayOpenScene(int scene)
    {
        var times = _animatorPanel.GetCurrentAnimatorClipInfo(0);
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(times.Length + 0.1f);

        yield return wait;

        SceneManager.LoadScene(scene);
    }
}
