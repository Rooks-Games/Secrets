using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueDatabase", menuName = "ScriptableObjects/DialogueDatabase")]
    public class DialogueDatabase : ScriptableObject
    {
        [Serialize] public readonly List<string> NpcIds;
        [Serialize] public readonly List<DialogueTree> DialogueTrees;
    }
}
