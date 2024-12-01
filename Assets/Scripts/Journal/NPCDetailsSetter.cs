using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NPCDetailsSetter : UIScreen
{
    [SerializeField] private Image NPCIcon;
    [SerializeField] private TMP_Text NPCName;
    [SerializeField] private TMP_Text NPCDescription;

    [SerializeField] private Button backButton;
    
    [SerializeField] private NpcDetails thisNPCDetails;
    
    [SerializeField] public List<ClueSetter> addedCluesButton = new();

    private void Start()
    {
        backButton.onClick.AddListener(journal.RemoveFromUIStack);
    }

    private void OnEnable()
    {
        base.OnEnable();
        if(thisNPCDetails.NpcName != "")
            DataSetter(thisNPCDetails);
    }
    
    public void DataSetter(NpcDetails currentNPCDetails)
    {
        NPCIcon = currentNPCDetails.NpcIcon;
        NPCName.text = currentNPCDetails.NpcName;
        NPCDescription.text = currentNPCDetails.NpcDescription;

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
