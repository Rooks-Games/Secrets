using System.Collections.Generic;
using Unity.VisualScripting;

namespace Scripts.DialogueSystem
{
    [System.Serializable]
    public class DialogueEntry
    {
        public readonly string speaker;
        public readonly string listener;
        public readonly int DialogueID;
        public readonly bool SkipDialogue;
        public readonly bool IsPlayerOption;
        public readonly string DialogueText;
        [Serialize] public readonly List<int> ChildEntries;
    }
}
