using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Npcs
{
    [System.Serializable]
    public class NpcMetaData
    {
        public NpcId id;
        public Sprite Image;
        public string Name;
        public string Description;
        public string DialogueTreeId;
    }
}
