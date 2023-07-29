using UnityEngine;

public class AutorsButton : MonoBehaviour
{
    [SerializeField] private AutorsPanel _autorsPanel;

    private void Start()
    {
        _autorsPanel.gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        _autorsPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
