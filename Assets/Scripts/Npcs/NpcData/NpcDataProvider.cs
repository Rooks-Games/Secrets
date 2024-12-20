using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Npcs
{
    public class NpcDataProvider : MonoBehaviour
    {
        [SerializeField] private NpcDatabase _npcDatabase;
        public Dictionary<NpcId, NpcData> NpcsData { get; private set; }

        private void Awake()
        {
            NpcsData = new Dictionary<NpcId, NpcData>();
            for (int i = 0; i < _npcDatabase.NpcsData.Count; i++)
            {
                NpcsData.Add(_npcDatabase.NpcsData[i].id, new NpcData(_npcDatabase.NpcsData[i]));
            }
        }
    }
}