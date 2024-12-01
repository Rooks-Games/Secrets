using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllNPCSelectionPage : UIScreen
{
    [SerializeField] List<NPCRecognition> listOfNPCs = new List<NPCRecognition>();
    public GameObject NPCPagePrefab;
    List<GameObject> allNPCsPages = new List<GameObject>();
    
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
        journal.ActivateNPCIconPage(this);
    }

    public void SetUIScreens(NPCRecognition npcRecognitionObject, int indexInList)
    {
        NPCDetailsSetter setterForCurrentNPC = null;
        NpcDetails npcDetails = new();
        
        GameObject NPCPageSpawned = Instantiate(NPCPagePrefab, MainJournalBG.transform);
        NPCPageSpawned.SetActive(false);
        
        npcDetails = journal.allNpcDetails[indexInList];
        NPCPageSpawned.name = $"{npcDetails.NpcName}_NPCPage";
                
        //Setup NPC Details object
                
        setterForCurrentNPC = NPCPageSpawned.GetComponent<NPCDetailsSetter>();
        setterForCurrentNPC.DataSetter(npcDetails);

        /*for (int i = 0 ; i < setterForCurrentNPC.addedCluesButton.Count; i++)
        {
            setterForCurrentNPC.addedCluesButton[i].AddImportantListeners();
        }*/

        npcRecognitionObject.charName.text = npcDetails.NpcName;
        npcRecognitionObject.charImage = npcDetails.NpcIcon;
        npcRecognitionObject.npcType = npcDetails.NpcIdentifier;
        npcRecognitionObject.BtnAddListener(() =>
        {
            NPCPageSpawned.SetActive(true);
            journal.AddToUIStack(NPCPageSpawned.GetComponent<UIScreen>());
        });
        
        allNPCsPages.Add(NPCPageSpawned);
        journal.AddToAllScreens(setterForCurrentNPC);
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