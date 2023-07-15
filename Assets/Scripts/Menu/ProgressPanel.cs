using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ProgressPanel : MonoBehaviour
{
    [SerializeField] private Button _closePanel;
    [SerializeField] private PanelColor _panel;
    [SerializeField] private Animator _animator;
    [SerializeField] private ProgressInfo _progressInfo;
    [SerializeField] private ProgressButton _progressButton;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnClose()
    {
        _panel.StartOff();
        AnimCloseScreen();
    }

    public void OnCloseScreen()
    {
        _progressButton.gameObject.SetActive(true);
        _progressInfo.gameObject.SetActive(false);
    }

    public void AnimCloseScreen()
    {
        _animator.SetBool("Open", false);
    }

    private void OnAnimOpenScreen()
    {
        _animator.SetBool("Open", true);
    }
}
