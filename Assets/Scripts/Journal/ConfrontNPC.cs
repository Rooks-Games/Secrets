using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Npcs;
using UnityEngine;
using UnityEngine.UI;

public class ConfrontNPC : MonoBehaviour
{
    [SerializeField] private NpcDataProvider _npcDataProvider;

    public bool Confront(NpcId npcId)
    {
        NpcData npcData = _npcDataProvider.NpcsData[npcId];
        int matched = 0;
        for (int i = 0; i < npcData.CorrectClues.Count; i++)
        {
            for (int j = 0; j < npcData.AddedClues.Count; j++)
            {
                if (npcData.CorrectClues[i].ClueDescription == npcData.AddedClues[j].ClueDescription)
                {
                    matched++;
                }
            }
        }

        int total = npcData.CorrectClues.Count;
        
        if (total == matched)
        {
            npcData.Loyalty = 1;
            return true;
        }
        
        if (matched == 0)
        {
            npcData.Loyalty = -1;
            return false;
        }
        
        int ans = UnityEngine.Random.Range(0, total + 1);
        if (ans <= matched)
        {
            npcData.Loyalty = 1;
            return true;
        }
        
        npcData.Loyalty = -1;
        return false;
    }

    public bool CanConfront(NpcId npcId)
    {
        return _npcDataProvider.NpcsData[npcId].AddedClues.Count > 0;
    }
}
