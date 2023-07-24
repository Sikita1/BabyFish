using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ClearScreen : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Button _button;
    [SerializeField] private Animator _animator;
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private ClearProgressPanel _progressPanel;
    [SerializeField] private PearlsCount _pearlsCount;
    [SerializeField] private LevelChanged _levelChanged;
    [SerializeField] private ViewProgress _viewProgress;
    [SerializeField] private ChangedScore _changedScore;

    [SerializeField] private Button _buttonClear;
    [SerializeField] private Button _buttonClose;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnDeactivateButtons()
    {
        ActivateButton(_buttonClear, false);
        ActivateButton(_buttonClose, false);
    }

    public void OnActivateButtons()
    {
        ActivateButton(_buttonClear, true);
        ActivateButton(_buttonClose, true);
    }

    public void OnExit()
    {
        AnimCloseScreen();
    }

    public void OnClearAll()
    {
        PlayerPrefs.DeleteAll();
        _score.ResetInvoice();
        _pearlsCount.ActualValue();
        _viewProgress.ViewCurrentScene();
        _changedScore.OnStartChangingIcon();
        AnimCloseScreen();
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

    private void AnimCloseScreen()
    {
        _panelColor.StartOff();
        _animator.SetBool("Open", false);
        
    }

    private void ActivateButton(Button button, bool isActivate)
    {
        button.gameObject.SetActive(isActivate);
    }
}
