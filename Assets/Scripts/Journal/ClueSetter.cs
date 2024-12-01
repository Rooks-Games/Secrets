using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Npcs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class ClueSetter : UIScreen
{
    [SerializeField] private TMP_Text clueName;
    [SerializeField] private TMP_Text clueDescription;

    [SerializeField] private NpcId currentNpcPage;
    [SerializeField] private ClueDetails currentClueObject;
    
    [SerializeField] GameObject questionMarkImage;
    [SerializeField] private Button cluePageButtonNPC, cluePageButtonClue, removeClueFromNPC, backButton;
    
    public override void OnEnable()
    {
        base.OnEnable();
        AddImportantListeners();
    }

    private void OnDisable()
    {
        if(backButton != null)
            backButton.onClick.RemoveAllListeners();
        if(cluePageButtonNPC != null)
            cluePageButtonNPC.onClick.RemoveAllListeners();
        if(cluePageButtonClue != null)
            cluePageButtonClue.onClick.RemoveAllListeners();
        if(removeClueFromNPC != null)
            removeClueFromNPC.onClick.RemoveAllListeners();
    }

    public void AddImportantListeners()
    {
        if(backButton != null)
            backButton.onClick.AddListener(journal.RemoveFromUIStack);
        if(cluePageButtonNPC != null)
            cluePageButtonNPC.onClick.AddListener(GotToClueAdditionForNPC);
        if(cluePageButtonClue != null)
            cluePageButtonClue.onClick.AddListener(AddClueToSpecificNPC);
        if(removeClueFromNPC != null)
            removeClueFromNPC.onClick.AddListener(RemoveClueFromNPC);
        
        if (currentClueObject.ClueName != "")
        {
            if(cluePageButtonNPC != null)
                ClueSetterOnNPCPage(currentClueObject);
            if(cluePageButtonClue != null)
                ClueSetterOnCluePage(currentClueObject);
        }
    }
    
    public void ClueSetterOnNPCPage(ClueDetails currentClueDetails)
    {
        questionMarkImage.gameObject.SetActive(false);
        cluePageButtonNPC.gameObject.SetActive(false);
        removeClueFromNPC.gameObject.SetActive(true);
        clueName.text = currentClueDetails.ClueName;
        clueName.gameObject.SetActive(true);
        currentClueObject = currentClueDetails;
    }

    public void ClueSetterOnCluePage(ClueDetails currentClueDetails)
    {
        clueName.text = currentClueDetails.ClueName;
        clueDescription.text = currentClueDetails.ClueDescription;
        if (journal.ActivateClueWithPlus)
        {
            cluePageButtonClue.gameObject.SetActive(true);
        }
        else
        {
            cluePageButtonClue.gameObject.SetActive(false);
        }
        currentClueObject = currentClueDetails;
    }

    public void GotToClueAdditionForNPC()
    {
        if (!journal.ActivateClueWithPlus)
        {
            journal.ActivateClueWithPlus = true;
            journal.SetJournalState(1);
        }
    }

    public void RemoveClueFromNPC()
    {
        if (currentClueObject.Selected)
        {
            questionMarkImage.gameObject.SetActive(true);
            clueName.text = "";
            clueName.gameObject.SetActive(false);
            removeClueFromNPC.gameObject.SetActive(false);
            cluePageButtonNPC.gameObject.SetActive(true);
            
            currentClueObject.Selected = false;
            journal.NpcDataProvider.NpcsData[journal.selectedNpc.id].AddedClues.Remove(currentClueObject);
        }
    }

    public void AddClueToSpecificNPC()
    {
        if (journal.ActivateClueWithPlus)
        {
            currentClueObject.Selected = true;
            journal.NpcDataProvider.NpcsData[journal.selectedNpc.id].AddedClues.Add(currentClueObject);
            
            journal.ActivateClueWithPlus = false;
            journal.selectedNpc = null;
            journal.RemoveFromUIStack();
            journal.RemoveFromUIStack();
        }
    }
}
