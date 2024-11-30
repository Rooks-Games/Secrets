using UnityEngine;

namespace Scripts.Npcs
{
    public class NpcData
    {
        public int Loyalty;
        
        private NpcMetaData _npcMetaData;
        public NpcId id => _npcMetaData.id;
        public Sprite Image => _npcMetaData.Image;
        public string Name => _npcMetaData.Name;
        public string Description => _npcMetaData.Description;
        public string DialogueTreeId => _npcMetaData.DialogueTreeId;
        
        public NpcData(NpcMetaData npcMetaData)
        {
            _npcMetaData = npcMetaData;
        }
    }
}