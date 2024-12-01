using System;
using System.Collections.Generic;
using Scripts.Npcs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NPCDetailsSetter : UIScreen
{
    [SerializeField] private Sprite NPCIcon;
    [SerializeField] private TMP_Text NPCName;
    [SerializeField] private TMP_Text NPCDescription;

    [SerializeField] private Button backButton;
    
    [SerializeField] private NpcData thisNPCDetails;
    
    [SerializeField] public List<ClueSetter> addedCluesButton = new();

    private void Start()
    {
        backButton.onClick.AddListener(journal.RemoveFromUIStack);
    }

    private void OnEnable()
    {
        base.OnEnable();
        if (thisNPCDetails != null)
        {
            DataSetter(journal.NpcDataProvider.NpcsData[thisNPCDetails.id]);
        }
    }
    
    public void DataSetter(NpcData currentNPCDetails)
    {
        NPCIcon = currentNPCDetails.Image;
        NPCName.text = currentNPCDetails.Name;
        NPCDescription.text = currentNPCDetails.Description;

        if (currentNPCDetails.AddedClues.Count > 0)
        {
            for (int index = 0; index < currentNPCDetails.AddedClues.Count; index++)
            {
                addedCluesButton[index].ClueSetterOnNPCPage(currentNPCDetails.AddedClues[index]);
            }
        }
        
        journal.selectedNpc = currentNPCDetails;
        
        thisNPCDetails = currentNPCDetails;
    }
    
}
