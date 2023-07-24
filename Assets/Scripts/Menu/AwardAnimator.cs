using System.Collections;
using UnityEngine;

public class AwardAnimator : MonoBehaviour
{
    [SerializeField] private ChangedScore _score;
    [SerializeField] private GameObject _panel;
    [SerializeField] private PanelColor _panelColor;
    [SerializeField] private PSAnim _pSAnim;

    private void Awake()
    {
        _panel.SetActive(false);
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
    }

    private void OnFinish()
    {
        _score.OnStartChangingIcon();
        _pSAnim.OnStartPS();
    }
}
