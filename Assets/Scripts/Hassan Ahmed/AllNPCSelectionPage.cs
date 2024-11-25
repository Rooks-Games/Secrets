using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AllNPCSelectionPage : UIScreen
{
    List<NPCRecognition> listOfNPCs = new List<NPCRecognition>();

    private void Start()
    {
        listOfNPCs = gameObject.GetComponentsInChildren<NPCRecognition>().ToList();

        for (int i = 0; i < listOfNPCs.Count; i++)
        {
            SetUIScreens(listOfNPCs[i].npcType);
        }
    }

    public void SetUIScreens(NpcList npcObj)
    {
        switch (npcObj)
        {
            case NpcList.Blacksmith:
                //Link the page to be opened in here!
                break;
            case NpcList.Baker:
                //Link the page to be opened in here!
                break;
            case NpcList.Herbalist:
                //Link the page to be opened in here!
                break;
            case NpcList.InKeeper:
                //Link the page to be opened in here!
                break;
            case NpcList.Priest:
                //Link the page to be opened in here!
                break;
            case NpcList.Farmer:
                //Link the page to be opened in here!
                break;
            case NpcList.Merchant:
                //Link the page to be opened in here!
                break;
            case NpcList.Scholar:
                //Link the page to be opened in here!
                break;
            case NpcList.TownChief:
                //Link the page to be opened in here!
                break;
            case NpcList.TownCrier:
                //Link the page to be opened in here!
                break;
            case NpcList.TownGuard:
                //Link the page to be opened in here!
                break;
        }
    }
}

[Serializable]
public enum NpcList
{
    Blacksmith,
    InKeeper,
    TownCrier,
    TownGuard,
    Herbalist,
    Priest,
    Baker,
    Merchant,
    Farmer,
    Scholar,
    TownChief
        
}