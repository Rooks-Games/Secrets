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
            SetUIScreens(listOfNPCs[i], i);
        }
    }

    private void Start()
    {
        journal.ActivateNPCIconPage();
    }

    public void SetUIScreens(NPCRecognition npcRecognitionObject, int indexInList)
    {
        NPCDetailsSetter setterForCurrentNPC = null;
        NpcDetails npcDetails = new();
        
        GameObject NPCPageSpawned = Instantiate(NPCPagePrefab, MainJournalBG.transform);
        NPCPageSpawned.SetActive(false);
        
        NPCPageSpawned.name = $"{npcDetails.NpcName}_NPCPage";
                
        //Setup NPC Details object
        npcDetails = allNpcDetails[indexInList];
                
        setterForCurrentNPC = NPCPageSpawned.GetComponent<NPCDetailsSetter>();
        setterForCurrentNPC.DataSetter(npcDetails);

        npcRecognitionObject.charName.text = npcDetails.NpcName;
        npcRecognitionObject.charImage = npcDetails.NpcIcon;
        npcRecognitionObject.npcType = npcDetails.NpcIdentifier;
        npcRecognitionObject.BtnAddListener(() =>
        {
            NPCPageSpawned.SetActive(true);
            journal.AddToUIStack(NPCPageSpawned.GetComponent<UIScreen>());
        });
                
        allNPCsPages.Add(NPCPageSpawned);
        JournalManager.Instance.allScreens.Add(setterForCurrentNPC);
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