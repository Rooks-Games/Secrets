using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Npcs;
using Unity.VisualScripting;
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
            SetUIScreens(listOfNPCs[i], listOfNPCs[i].npcType);
        }
    }

    private void Start()
    {
        journal.ActivateNPCIconPage(this);
    }

    public void SetUIScreens(NPCRecognition npcRecognitionObject, NpcId id)
    {
        NPCDetailsSetter setterForCurrentNPC = null;
        NpcData npcData;
        
        GameObject NPCPageSpawned = Instantiate(NPCPagePrefab, MainJournalBG.transform);
        NPCPageSpawned.SetActive(false);
        
        npcData = journal.NpcDataProvider.NpcsData[id];
        NPCPageSpawned.name = $"{npcData.Name}_NPCPage";
                
        //Setup NPC Details object
                
        setterForCurrentNPC = NPCPageSpawned.GetComponent<NPCDetailsSetter>();
        setterForCurrentNPC.DataSetter(npcData);

        /*for (int i = 0 ; i < setterForCurrentNPC.addedCluesButton.Count; i++)
        {
            setterForCurrentNPC.addedCluesButton[i].AddImportantListeners();
        }*/

        npcRecognitionObject.charName.text = npcData.Name;
        npcRecognitionObject.charImage.sprite = npcData.Image;
        npcRecognitionObject.npcType = npcData.id;
        npcRecognitionObject.BtnAddListener(() =>
        {
            NPCPageSpawned.SetActive(true);
            journal.AddToUIStack(NPCPageSpawned.GetComponent<UIScreen>());
        });
        
        allNPCsPages.Add(NPCPageSpawned);
        journal.AddToAllScreens(setterForCurrentNPC);
    }
}