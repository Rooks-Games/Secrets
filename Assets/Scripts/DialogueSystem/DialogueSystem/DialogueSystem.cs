using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.DialogueSystem
{
    public class DialogueSystem : MonoBehaviour
    {
        private DialogueUI _dialogueUI;
        private DialogueDependencies _dependencies;
        private DialogueController _dialogueController;

        public event Action ConversationStarted;
        public event Action ConversationEnded;

        public void Init(DialogueDependencies dependencies)
        {
            _dependencies = dependencies;
            _dialogueController = new DialogueController(_dependencies);
            _dialogueUI = GetComponent<DialogueUI>();
            _dialogueUI.Init(_dependencies);
            _dialogueUI.ContinueDialogueFromEntry = ContinueConversation;
        }
        
        public bool StartConversation(string npcId)
        {
            if (_dialogueController.StartDialogue(npcId))
            {
                return false;
            }
            
            ConversationStarted?.Invoke();
            _dialogueUI.ShowDialogueUI();
            ShowCurrentDialogue();
            return true;
        }

        private void ContinueConversation(int currentDialogueId)
        {
            if (_dialogueController.ContinueDialogue(currentDialogueId))
            {
                ShowCurrentDialogue();
                return;
            }

            EndConversation();
        }

        private void EndConversation()
        {
            _dialogueUI.HideDialogueUI();
            ConversationEnded?.Invoke();
        }

        private void ShowCurrentDialogue()
        {
            List<DialogueEntry> possibleDialogueEntries = _dialogueController.CurrentPossibleDialoguesList;
            if (possibleDialogueEntries[0].IsPlayerOption)
            {
                _dialogueUI.ShowPlayerOptions(possibleDialogueEntries);
            }
            else
            {
                _dialogueUI.ShowNpcDialogue(possibleDialogueEntries[0]);
            }
        }
    }
}
