using System;
using System.Collections.Generic;
using Scripts.DialogueSystem;
using UnityEngine;

public class DialoguePlayerOptionsUI : MonoBehaviour
{
    [SerializeField] private Transform _optionParent;
    [SerializeField] private DialoguePlayerOptionButton _optionButtonPrefab;
    private List<DialoguePlayerOptionButton> _optionButtons;
    private DialogueDependencies _dependencies;
    
    public Action<int> ContinueDialogueFromEntry;
    
    public void Init(DialogueDependencies dialogueDependencies)
    {
        _dependencies = dialogueDependencies;
    }
    
    public void ShowPlayerOptions(List<DialogueEntry> options)
    {
        _optionButtons = new List<DialoguePlayerOptionButton>();
        for (int i = 0; i < options.Count; i++) 
        {
            DialoguePlayerOptionButton button = Instantiate(_optionButtonPrefab, _optionParent);
            button.Init(options[i], PlayerOptionSelected);
            _optionButtons.Add(button);
        }
    }
    
    public void PlayerOptionSelected(int dialogueId)
    {
        for (int i = _optionButtons.Count - 1; i >= 0; i--) 
        {
            Destroy(_optionButtons[i].gameObject);
        }
        _optionButtons?.Clear();
        ContinueDialogueFromEntry?.Invoke(dialogueId);
    }
}
