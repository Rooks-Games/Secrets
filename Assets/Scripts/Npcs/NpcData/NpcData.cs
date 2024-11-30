using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Npcs
{
    [System.Serializable]
    public class NpcData
    {
        public NpcType Type;
        public Sprite Image;
        public string Name;
        public string Description;
        public string DialogueTreeId;
    }
}
