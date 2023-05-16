using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour
{
    [SerializeField] private string _phrase;
    private Dictionary<string, Action> _keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer _keywordRecognizer;
    void Start()
    {
        _keywordActions.Add(_phrase, CompleteGame);

        _keywordRecognizer = new KeywordRecognizer(_keywordActions.Keys.ToArray());
        _keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        _keywordRecognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword " + args.text);
        _keywordActions[args.text].Invoke();
    }
    void CompleteGame()
    {
        Debug.Log("Game completed");
    }
}
