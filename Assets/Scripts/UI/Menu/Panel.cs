using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IPointerExitHandler
{
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
