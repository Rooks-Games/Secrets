using System.Collections.Generic;
using Unity.VisualScripting;

namespace Scripts.DialogueSystem
{
    [System.Serializable]
    public class DialogueEntry
    {
        public string speaker;
        public string listener;
        public int DialogueID;
        public bool SkipDialogue;
        public bool IsPlayerOption;
        public string DialogueText;
        [Serialize] public List<int> ChildEntries;
    }
}
