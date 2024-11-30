using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ClueUI : UIScreen
{
    [SerializeField] ScrollRect cluesScrollRect;
    [SerializeField] GameObject clueButtonPrefab, clueButtonPage;
    [SerializeField]List<ClueDetails> clues = new List<ClueDetails>();
    
    [SerializeField]List<GameObject> allCluePages = new List<GameObject>();
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < clues.Count; i++)
        {
            GameObject clueButtonObject = Instantiate(clueButtonPrefab, cluesScrollRect.content);
            ClueButtonListener clueButton = clueButtonObject.GetComponent<ClueButtonListener>();
            string buttonTitleName = clues[i].ClueName;
            clueButton.SetClueButtonText(buttonTitleName);
            
            GameObject cluePageObject = Instantiate(clueButtonPage, MainJournalBG.transform);
            ClueSetter setterObject = cluePageObject.GetComponent<ClueSetter>();
            
            setterObject.journal = journal;
            setterObject.MainJournalBG = MainJournalBG;
            
            setterObject.ClueSetterOnCluePage(clues[i]);
            
            clueButton.BtnAddListener(()=>
            {
                cluePageObject.SetActive(true);
                journal.AddToUIStack(cluePageObject.GetComponent<UIScreen>());
            });
            
            cluePageObject.SetActive(false);
            allCluePages.Add(cluePageObject);
            JournalManager.Instance.allScreens.Add(setterObject);
        }
    }
    
    
}
