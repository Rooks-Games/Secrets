using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllNPCSelectionPage : UIScreen
{
    [SerializeField] List<NPCRecognition> listOfNPCs = new List<NPCRecognition>();
    public GameObject NPCPagePrefab;
    List<GameObject> allNPCsPages = new List<GameObject>();
    
    [SerializeField] List<NpcDetails> allNpcDetails = new List<NpcDetails>();
    
    private void Awake()
    {
        listOfNPCs = gameObject.GetComponentsInChildren<NPCRecognition>(true).ToList();

        for (int i = 0; i < listOfNPCs.Count; i++)
        {
            SetUIScreens(listOfNPCs[i].npcType, listOfNPCs[i], i);
        }
    }

    private void Start()
    {
        journal.ActivateNPCIconPage();
    }

    public void SetUIScreens(NpcList npcObj, NPCRecognition npcRecognitionObject, int indexInList)
    {
        NPCDetailsSetter setterForCurrentNPC = null;
        NpcDetails npcDetails = new();
        
        GameObject NPCPageSpawned = Instantiate(NPCPagePrefab, MainJournalBG.transform);
        NPCPageSpawned.SetActive(false);
        
        switch (npcObj)
        {
            case NpcList.Blacksmith:
                //Link the page to be opened in here!
                NPCPageSpawned.name = $"{npcDetails.NpcName}_NPCPage";
                
                //Setup NPC Details object
                npcDetails = allNpcDetails[indexInList];
                
                setterForCurrentNPC = NPCPageSpawned.GetComponent<NPCDetailsSetter>();
                setterForCurrentNPC.DataSetter(npcDetails);

                npcRecognitionObject.charName.text = npcDetails.NpcName;
                npcRecognitionObject.charImage = npcDetails.NpcIcon;
                npcRecognitionObject.BtnAddListener(() =>
                {
                    NPCPageSpawned.SetActive(true);
                    journal.AddToUIStack(NPCPageSpawned.GetComponent<UIScreen>());
                });
                
                allNPCsPages.Add(NPCPageSpawned);
                JournalManager.Instance.allScreens.Add(setterForCurrentNPC);
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