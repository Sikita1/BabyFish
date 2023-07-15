using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ClearScreen : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Score _score;
    [SerializeField] private Animator _animator;
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private ClearProgressPanel _progressPanel;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnExit()
    {
        AnimCloseScreen();
    }

    public void OnClearAll()
    {
        _panelColor.StartOff();
        PlayerPrefs.DeleteAll();
        AnimCloseScreen();
        _score.ResetInvoice();
    }

    private void AnimCloseScreen()
    {
        _panelColor.StartOff();
        _animator.SetBool("Open", false);
    }

    public void OnAnimOpenScreen()
    {
        _animator.SetBool("Open", true);
    }

    public void OnCloseScreen()
    {
        _button.gameObject.SetActive(true);
        _progressPanel.gameObject.SetActive(false);
    }
}
