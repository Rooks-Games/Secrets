using System.Collections.Generic;
using Scripts.Npcs;
using Unity.VisualScripting;

namespace Scripts.DialogueSystem
{
    [System.Serializable]
    public class DialogueEntry
    {
        public int DialogueID;
        public bool SkipDialogue;
        public bool IsPlayerOption;
        public string DialogueText;
        [Serialize] public List<int> ChildEntries;
    }
}