using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTrigger : MonoBehaviour
{
    [SerializeField] private TrainingManager _training;
    [SerializeField] private Dialogue _dialogue;

    private void Start()
    {
        _training.StartDialogue(_dialogue);
        StartCoroutine(DelayStart());
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(0.2f);

        Time.timeScale = 0f;
    }
}
