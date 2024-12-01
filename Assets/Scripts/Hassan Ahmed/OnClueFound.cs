using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnClueFound : MonoBehaviour
{
    public string ClueName;
    [SerializeField] JournalManager journalManager;

    private void Start()
    {
        journalManager = GameObject.Find("Journal Manager").GetComponent<JournalManager>();
    }

    public void ClueFound()
    {
        ClueDetails clueFound = journalManager.allClueDetails.Find(x=>x.ClueName == ClueName);
        clueFound.FoundORNotFound = true;
        journalManager.PopupHandler(clueFound.ClueName + " Found!");
    }
}
