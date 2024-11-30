using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Npcs
{
    public class NpcDataProvider : MonoBehaviour
    {
        [SerializeField] private NpcDatabase _npcDatabase;
        public Dictionary<NpcType, NpcData> NpcsData { get; private set; }

        private void Start()
        {
            NpcsData = new Dictionary<NpcType, NpcData>();
            for (int i = 0; i < _npcDatabase.NpcsData.Count; i++)
            {
                NpcsData.Add(_npcDatabase.NpcsData[i].Type, _npcDatabase.NpcsData[i]);
            }
        }
    }
}