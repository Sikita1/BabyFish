using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class Garbage : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private DestroyExplotion _explotion;

    public event UnityAction<Garbage> GarbageCountChanged;

    private void Start()
    {
        //Application.targetFrameRate = 60;
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Mathf.Abs(_sprite.color.a - 1f) < float.Epsilon)
        {
            GarbageCountChanged?.Invoke(this);
            Instantiate(_explotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void SetLayer(float alfa, int layer)
    {
        var color = _sprite.color;
        color.a = alfa;
        _sprite.color = color;

        _sprite.sortingOrder = layer;
    }

    public void LayerUp()
    {
        float alfaUp = 0.3f;
        var color = _sprite.color;

        color.a += alfaUp;
        _sprite.color = color;
        _sprite.sortingOrder++;
    }

    private float ShowSmoothly(float value)
    {
        while (true)
            return Mathf.Lerp(0f, value, 5f * Time.deltaTime);
    }
}
