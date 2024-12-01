using System;
using Scripts.Npcs;

namespace Scripts.Map
{
    public class InteractableNpc : InteractableObject
    {
        public NpcId Id;
        
        private void Start()
        {
            Type = InteractableObjectType.Npc;
        }
    }
}