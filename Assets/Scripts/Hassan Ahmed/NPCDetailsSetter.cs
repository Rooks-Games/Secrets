using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDetailsSetter : UIScreen
{
    [SerializeField] private Image NPCIcon;
    [SerializeField] private TMP_Text NPCName;
    [SerializeField] private TMP_Text NPCDescription;
    
    NpcList currentNPCIdentifier;
    
    //Clues Handling
    
    
    public void DataSetter(NpcDetails currentNPCDetails)
    {
        NPCIcon = currentNPCDetails.NpcIcon;
        NPCName.text = currentNPCDetails.NpcName;
        NPCDescription.text = currentNPCDetails.NpcDescription;
        
        //Clues
        
        
        currentNPCIdentifier = currentNPCDetails.NpcIdentifier;
    }
}
