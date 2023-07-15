using UnityEngine;

public class ClearProgressButton : MonoBehaviour
{
    [SerializeField] private ClearProgressPanel _clearScreen;
    [SerializeField] private PanelColor _panelColor;

    private void Start()
    {
        gameObject.SetActive(true);
        _clearScreen.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        _clearScreen.gameObject.SetActive(true);
        _panelColor.StartOn();
        gameObject.SetActive(false);
    }
}
