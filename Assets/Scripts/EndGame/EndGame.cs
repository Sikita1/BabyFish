using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Image _image1;
    [SerializeField] private Image _image2;

    [SerializeField] private TMP_Text _button;
    [SerializeField] private TMP_Text _gratitudeText;

    private string _gratitude = "Вы справились! Благодаря Вам, мне удалось вернуть всех моих детишек.";
    private string _textMenu = "Меню";

    private void Start()
    {
        _gratitudeText.text = _gratitude;

        _image2.gameObject.SetActive(false);
    }

    public void OnNextButtonClick()
    {
        if (_button.text == _textMenu)
            SceneManager.LoadScene(0);

        _button.text = _textMenu;
        _image1.gameObject.SetActive(false);
        _image2.gameObject.SetActive(true);
    }
}
