using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueTree", menuName = "ScriptableObjects/DialogueTree")]
    public class DialogueTree : ScriptableObject
    {
        public string Id;
        [Serialize] public List<DialogueEntry> DialogueEntries;
    }
}
