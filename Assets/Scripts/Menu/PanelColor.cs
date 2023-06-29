using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelColor : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxAlfa;

    private Coroutine _coroutine;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartOn()
    {
        _coroutine = StartCoroutine(Blackout(0f, _maxAlfa));
    }

    public void StartOff()
    {
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(Blackout(_maxAlfa, 0f));
    }

    private IEnumerator Blackout(float current, float target)
    {
        var color = _image.color;

        color.a = (1f / 255f * current);

        while (color.a != target)
        {
            color.a = Mathf.MoveTowards(color.a, (1f / 255f * target), Time.deltaTime / _delay);
            _image.color = color;
            yield return null;
        }
    }
}
