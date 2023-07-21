using UnityEngine;
using UnityEngine.Events;

public class ProgressButton : MonoBehaviour
{
    [SerializeField] private ProgressInfo _panel;
    [SerializeField] private PanelColor _panelColor;

    public event UnityAction PanelOpening;

    private void Start()
    {
        gameObject.SetActive(true);
        _panel.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        PanelOpening?.Invoke();
        _panel.gameObject.SetActive(true);
        gameObject.SetActive(false);
        _panelColor.StartOn();
    }
}
