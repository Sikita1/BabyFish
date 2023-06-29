using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonMusic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Panel _panel;

    private void Start()
    {
        _panel.gameObject.SetActive(false);
        _animator.GetComponent<Animator>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData e)
    {
        _panel.gameObject.SetActive(true);
        _animator.SetBool("Appeared", true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData e)
    {
        _animator.SetBool("Appeared", false);
    }
}
