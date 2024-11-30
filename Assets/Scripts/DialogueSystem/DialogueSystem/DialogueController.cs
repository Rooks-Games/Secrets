using System.Collections.Generic;

namespace Scripts.DialogueSystem
{
    public class DialogueController
    {
        private DialogueDependencies _dependencies;
        private Dictionary<string, Dictionary<int, DialogueEntry>> _dialogueData;
        private DialogueHelper _dialogueHelper;
        private List<DialogueEntry> _activeDialoguesList;
        private string _activeDialogueTreeId;
        
        public List<DialogueEntry> CurrentPossibleDialoguesList;
        
        private Dictionary<int, DialogueEntry> _activeDialogueTree => _dialogueData[_activeDialogueTreeId];

        public DialogueController(DialogueDependencies dialogueDependencies)
        {
            _dependencies = dialogueDependencies;
            _dialogueHelper = new DialogueHelper(_dependencies);
            PrepareDialogueData();
            ResetDialogue();
        }

        public bool StartDialogue(string dialogueTreeId)
        {
            if (!_dialogueData.TryGetValue(dialogueTreeId, out Dictionary<int, DialogueEntry> dialogueData))
            {
                return false;
            }
            
            _activeDialogueTreeId = dialogueTreeId;
            _activeDialoguesList = new List<DialogueEntry> { GetDialogue(0) };

            if (_activeDialoguesList.Count == 1 && !_activeDialoguesList[0].SkipDialogue)
            {
                return true;
            }

            return ContinueDialogue(_activeDialoguesList[0].DialogueID);
        }

        public bool ContinueDialogue(int dialogueId)
        {
            if (_activeDialogueTreeId == "" || dialogueId == -1)
            {
                return false;
            }

            List<DialogueEntry> nextEntries = GetFilteredChildEntries(dialogueId);
            if (nextEntries.Count == 0)
            {
                ResetDialogue();
                return false;
            }

            while (nextEntries[0].SkipDialogue)
            {
                nextEntries = GetFilteredChildEntries(dialogueId);
                if (nextEntries.Count == 0)
                {
                    ResetDialogue();
                    return false;
                }
            }
            
            _activeDialoguesList = nextEntries;
            return true;
        }
        
        private DialogueEntry GetDialogue(int dialogueEntryId)
        {
            return _activeDialogueTree[dialogueEntryId];
        }
        
        private void ResetDialogue()
        {
            _activeDialogueTreeId = "";
            _activeDialoguesList?.Clear();
        }

        private List<DialogueEntry> GetFilteredChildEntries(int parentEntryId)
        {
            List<DialogueEntry> nextEntries = GetChildEntries(parentEntryId);
            List<DialogueEntry> filteredEntries = FilterEntries(nextEntries);
            
            List<DialogueEntry> finalEntries = filteredEntries;
            if (filteredEntries.Count >= 1 && !filteredEntries[0].IsPlayerOption)
            {
                finalEntries = new List<DialogueEntry> { filteredEntries[0] };
            }

            return finalEntries;
        }
        
        private List<DialogueEntry> GetChildEntries(int parentEntryId)
        {
            List<int> childEntriesIndexes = _activeDialogueTree[parentEntryId].ChildEntries;
            List<DialogueEntry> childEntriesList = new List<DialogueEntry>();
            for (int i = 0; i < childEntriesIndexes.Count; i++)
            {
                childEntriesList.Add(GetDialogue(childEntriesIndexes[i]));
            }
            
            return childEntriesList;
        }
        
        private List<DialogueEntry> FilterEntries(List<DialogueEntry> entries)
        {
            return FilterEntriesBySpeaker(FilterEntriesByCondition(entries));
        }

        private List<DialogueEntry> FilterEntriesByCondition(List<DialogueEntry> entries)
        {
            List<DialogueEntry> filteredEntriesList = new List<DialogueEntry>();
            for (int i = 0; i < entries.Count; i++)
            {
                if (CheckConditionForDialogue(entries[i].DialogueID))
                {
                    filteredEntriesList.Add(entries[i]);   
                }
            }
            
            return filteredEntriesList;
        }
        
        private List<DialogueEntry> FilterEntriesBySpeaker(List<DialogueEntry> entries)
        {
            List<DialogueEntry> filteredEntriesList = new List<DialogueEntry>();
            if (entries.Count == 0)
            {
                return filteredEntriesList;
            }

            string currentSpeaker = entries[0].speaker;
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].speaker == currentSpeaker)
                {
                    filteredEntriesList.Add(entries[i]);   
                }
            }
            
            return filteredEntriesList;
        }

        private bool CheckConditionForDialogue(int dialogueEntryId)
        {
            return _dialogueHelper.CheckConditionForDialogueEntry(_activeDialogueTree[dialogueEntryId]);
        }
        
        private void PerformActionForDialogue(int dialogueEntryId)
        {
            _dialogueHelper.PerformActionForDialogueEntry(_activeDialogueTree[dialogueEntryId]);
        }

        private void PrepareDialogueData()
        {
            _dialogueData = new Dictionary<string, Dictionary<int, DialogueEntry>>();
            for (int i = 0; i < _dependencies.DialogueDatabase.DialogueTrees.Count; i++)
            {
                DialogueTree dialogueTree = _dependencies.DialogueDatabase.DialogueTrees[i];
                Dictionary<int, DialogueEntry> dialogueEntries = new Dictionary<int, DialogueEntry>();
                for (int j = 0; j < dialogueTree.DialogueEntries.Count; j++)
                {
                    dialogueEntries.Add(dialogueTree.DialogueEntries[j].DialogueID, dialogueTree.DialogueEntries[j]);
                }
                _dialogueData.Add(dialogueTree.Id, dialogueEntries);
            }
        }
    }
}