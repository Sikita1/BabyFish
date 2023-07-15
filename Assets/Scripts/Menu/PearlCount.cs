using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PearlCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _text.text = "0";
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
}
