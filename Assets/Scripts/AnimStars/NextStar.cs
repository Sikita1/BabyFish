using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStar : MonoBehaviour
{
    [SerializeField] private GameObject _star;

    private void OnStarAnim()
    {
        _star.SetActive(true);
    }
}
