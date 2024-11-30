using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.DialogueSystem
{
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField] private DialogueUI _dialogueUIPrefab;
        
        private DialogueUI _dialogueUI;
        private DialogueDependencies _dependencies;
        private DialogueController _dialogueController;

        public event Action ConversationStarted;
        public event Action ConversationEnded;

        public void Init(DialogueDependencies dependencies)
        {
            _dependencies = dependencies;
            _dialogueController = new DialogueController(_dependencies);
        }
        
        public bool StartConversation(string npcId)
        {
            if (_dialogueController.StartDialogue(npcId))
            {
                return false;
            }
            
            ConversationStarted?.Invoke();
            //Show UI
            ShowCurrentDialogue();
            return true;
        }

        private void ContinueConversation()
        {
            if (_dialogueController.ContinueDialogue())
            {
                ShowCurrentDialogue();
                return;
            }

            EndConversation();
        }

        private void EndConversation()
        {
            //Hide UI
            ConversationEnded?.Invoke();
        }

        private void ShowCurrentDialogue()
        {
            List<DialogueEntry> possibleDialogueEntries = _dialogueController.CurrentPossibleDialoguesList;
            if (possibleDialogueEntries[0].IsPlayerOption)
            {
                
            }
            
            //Show Dialogue
        }
    }
}
