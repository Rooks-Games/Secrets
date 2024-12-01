using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfrontNPC : MonoBehaviour
{
    [SerializeField] private NpcList npcToConfront;
    [SerializeField] Button confrontButton;
    JournalManager journalManager;
    
    private void Start()
    {
        journalManager = GameObject.Find("Journal Manager").GetComponent<JournalManager>(); 
    }

    public void Confront()
    {
        if (CanConfront())
        {
            //Can Confront!!
        }
        else
        {
            //Can not confront!!
        }
    }

    public bool CanConfront()
    {
        return journalManager.allNpcDetails.Find(a => a.NpcIdentifier == npcToConfront).AddedClues.Count > 0;
    }
}
