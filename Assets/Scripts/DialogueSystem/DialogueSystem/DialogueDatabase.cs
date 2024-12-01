using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueDatabase", menuName = "ScriptableObjects/DialogueDatabase")]
    public class DialogueDatabase : ScriptableObject
    {
        [Serialize] public List<DialogueTree> DialogueTrees;
    }
}
