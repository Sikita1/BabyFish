using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestroyExplotion : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _audioSource.Play();
    }

    private void OnDestroyBoom()
    {
        Destroy(gameObject);
    }
}
