using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueTree", menuName = "ScriptableObjects/DialogueTree")]
    public class DialogueTree : ScriptableObject
    {
        public readonly string Id;
        [Serialize] public readonly List<DialogueEntry> DialogueEntries;
    }
}
