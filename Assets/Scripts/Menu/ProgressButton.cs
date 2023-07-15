using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressButton : MonoBehaviour
{
    [SerializeField] private ProgressInfo _panel;
    [SerializeField] private PanelColor _panelColor;

    private void Start()
    {
        gameObject.SetActive(true);
        _panel.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        _panel.gameObject.SetActive(true);
        gameObject.SetActive(false);
        _panelColor.StartOn();
    }
}
