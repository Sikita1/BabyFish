using UnityEngine;
using UnityEngine.UI;

public class AutorsPanel : MonoBehaviour
{
    [SerializeField] private Button _infoPanelButton;

    public void ClosePanel()
    {
        _infoPanelButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
