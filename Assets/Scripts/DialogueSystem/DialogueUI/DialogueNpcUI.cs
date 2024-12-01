using System;
using Scripts.DialogueSystem;
using Scripts.Npcs;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

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
        NpcData npcData = _dependencies.NpcDataProvider.NpcsData[dialogue.NpcId];
        _npcImage.sprite = npcData.Image;
    }
    
    public void ContinueDialogue()
    {
        ContinueDialogueFromEntry?.Invoke(_currentDialogue.DialogueID);
    }
}
