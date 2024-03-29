using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _dialogue;

    [SerializeField] private Image _historyImage;
    [SerializeField] private Image _trainingImage;
    [SerializeField] private TMP_Text _button;
    [SerializeField] private Training _canvas;
    [SerializeField] private Button _buttonNext;

    private Queue<string> _sentences;

    private Coroutine _corutine;

    private void Start()
    {
        StartTraining();
    }

    public void StartTraining()
    {
        _trainingImage.gameObject.SetActive(false);
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

        ActivButtonNext(false);

        foreach (char letter in sentence.ToCharArray())
        {
            _dialogue.text += letter;
            yield return null;
        }

        ActivButtonNext(true);
    }

    private void ActivButtonNext(bool isState)
    {
        _buttonNext.gameObject.SetActive(isState);
    }

    private void EndDialogue()
    {
        _historyImage.gameObject.SetActive(false);
        _trainingImage.gameObject.SetActive(true);

        _button.text = "������ ����";
    }

    private void StartGame()
    {
        if (_button.text == "������ ����")
        {
            _canvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
