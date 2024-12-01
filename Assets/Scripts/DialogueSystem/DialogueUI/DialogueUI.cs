using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.DialogueSystem
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private DialoguePlayerOptionsUI _dialoguePlayerOptionsUI;
        [SerializeField] private DialogueNpcUI _dialogueNpcUI;
        private DialogueDependencies _dependencies;
        
        public Action<int> ContinueDialogueFromEntry;
        
        public void Init(DialogueDependencies dialogueDependencies)
        {
            _dependencies = dialogueDependencies;
            _dialogueNpcUI.Init(dialogueDependencies);
            _dialogueNpcUI.ContinueDialogueFromEntry = ContinueDialogueFrom;
            _dialoguePlayerOptionsUI.ContinueDialogueFromEntry = ContinueDialogueFrom;
        }

        public void ShowNpcDialogue(DialogueEntry dialogueEntry)
        {
            _dialoguePlayerOptionsUI.gameObject.SetActive(false);
            _dialogueNpcUI.ShowDialogue(dialogueEntry);
            _dialogueNpcUI.gameObject.SetActive(true);
        }
        
        public void ShowPlayerOptions(List<DialogueEntry> dialogueEntries)
        {
            _dialogueNpcUI.gameObject.SetActive(false);
            _dialoguePlayerOptionsUI.ShowPlayerOptions(dialogueEntries);
            _dialoguePlayerOptionsUI.gameObject.SetActive(true);
        }
        
        public void ShowDialogueUI()
        {
            gameObject.SetActive(true);
        }
        
        public void HideDialogueUI()
        {
            gameObject.SetActive(false);
        }

        public void ContinueDialogueFrom(int dialogueId)
        {
            ContinueDialogueFromEntry?.Invoke(dialogueId);
        }
    }
}
