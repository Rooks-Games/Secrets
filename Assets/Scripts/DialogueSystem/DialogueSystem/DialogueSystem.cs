using System;
using System.Collections.Generic;
using Scripts.Npcs;
using UnityEngine;

namespace Scripts.DialogueSystem
{
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField] private DialogueDependencies _dependencies;
        private DialogueUI _dialogueUI;
        private DialogueController _dialogueController;

        public event Action ConversationStarted;
        public event Action ConversationEnded;

        public void Start()
        {
            _dialogueController = new DialogueController(_dependencies);
            _dialogueUI = GetComponent<DialogueUI>();
            _dialogueUI.Init(_dependencies);
            _dialogueUI.ContinueDialogueFromEntry = ContinueConversation;
            StartConversation("test");
        }
        
        public bool StartConversationWith(NpcId npc)
        {
            return StartConversation(_dependencies.NpcDataProvider.NpcsData[npc].DialogueTreeId);
        }
        
        public bool StartConversation(string npcId)
        {
            if (!_dialogueController.StartDialogue(npcId))
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
