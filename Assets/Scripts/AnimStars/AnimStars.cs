using UnityEngine;

public class AnimStars : MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;

    private void Start()
    {
        foreach (var star in _stars)
            star.SetActive(false);
    }

    private void OnStarLeft()
    {
        _stars[0].SetActive(true);
    }
}
