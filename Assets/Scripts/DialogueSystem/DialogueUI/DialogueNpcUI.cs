using System;
using Scripts.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class DialogueNpcUI : MonoBehaviour
{
    [SerializeField] private Image _npcImage;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private Button _dialogueBox;
    
    private DialogueEntry _currentDialogue;
    private DialogueDependencies _dependencies;
    
    public Action<int> ContinueDialogueFromEntry;
    
    public void Init(DialogueDependencies dialogueDependencies)
    {
        _dependencies = dialogueDependencies;
        _dialogueBox.onClick.AddListener(ContinueDialogue);
    }
    
    public void ShowDialogue(DialogueEntry dialogue)
    {
        _currentDialogue = dialogue;
        _dialogueText.SetText(_currentDialogue.DialogueText);
    }
    
    public void ContinueDialogue()
    {
        ContinueDialogueFromEntry?.Invoke(_currentDialogue.DialogueID);
    }
}
