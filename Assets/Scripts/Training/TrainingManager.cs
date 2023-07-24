using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _dialogue;

    [SerializeField] private Image _history;
    [SerializeField] private Image _training;
    [SerializeField] private TMP_Text _button;
    [SerializeField] private GameObject _canvas;

    private Queue<string> _sentences;

    private Coroutine _corutine;

    private void Start()
    {
        StartTraining();
    }

    public void StartTraining()
    {
        _training.gameObject.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _sentences = new Queue<string>();
        
        if (_sentences != null)
            _sentences.Clear();

        foreach (string sentence in dialogue.Sentences)
            _sentences.Enqueue(sentence);

        DisplayNextSentences();
    }

    public void DisplayNextSentences()
    {
        if (_sentences.Count == 0)
        {
            StartGame();
            EndDialogue();
            return;
        }

        string sentences = _sentences.Dequeue();
        _corutine = StartCoroutine(TypeSentence(sentences));

        if (_corutine != null)
            StopCoroutine(_corutine);

        StartCoroutine(TypeSentence(sentences));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        _dialogue.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            _dialogue.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        _history.gameObject.SetActive(false);
        _training.gameObject.SetActive(true);

        _button.text = "Начать игру";
    }

    private void StartGame()
    {
        if (_button.text == "Начать игру")
        {
            _canvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
