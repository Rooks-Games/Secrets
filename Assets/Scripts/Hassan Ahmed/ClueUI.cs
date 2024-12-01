using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ClueUI : UIScreen
{
    [SerializeField] ScrollRect cluesScrollRect;
    [SerializeField] GameObject clueButtonPrefab, clueButtonPage;
    [SerializeField]List<GameObject> allCluePages = new List<GameObject>();
    [SerializeField]List<ClueButtonListener> allClueButtons = new List<ClueButtonListener>();
    
    [SerializeField] private Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(journal.RemoveFromUIStack);
    }

    private void Awake()
    {
        for (int i = 0; i < journal.allClueDetails.Count; i++)
        {
            GameObject clueButtonObject = Instantiate(clueButtonPrefab, cluesScrollRect.content);
            ClueButtonListener clueButton = clueButtonObject.GetComponent<ClueButtonListener>();
            allClueButtons.Add(clueButton);
            if (journal.allClueDetails[i].FoundORNotFound)
            {
                clueButton.ClueFound(journal.allClueDetails[i]);
            }
            else
            {
                clueButton.ClueNotFound();
            }
            
            GameObject cluePageObject = Instantiate(clueButtonPage, MainJournalBG.transform);
            ClueSetter setterObject = cluePageObject.GetComponent<ClueSetter>();
            setterObject.journal = journal;
            setterObject.MainJournalBG = MainJournalBG;
            setterObject.ClueSetterOnCluePage(journal.allClueDetails[i]);
            
            clueButton.BtnAddListener(()=>
            {
                cluePageObject.SetActive(true);
                journal.AddToUIStack(cluePageObject.GetComponent<UIScreen>());
            });
            cluePageObject.SetActive(false);
            allCluePages.Add(cluePageObject);
            journal.AddToAllScreens(setterObject);
        }
    }

    // Start is called before the first frame update
    public override void OnEnable()
    {
        base.OnEnable();
        for (int i = 0; i < allClueButtons.Count; i++)
        {
            ClueButtonListener clueButton = allClueButtons[i];
            if (journal.allClueDetails[i].FoundORNotFound)
            {
                clueButton.ClueFound(journal.allClueDetails[i]);
            }
            else
            {
                clueButton.ClueNotFound();
            }
            clueButton.ClueSelectedState(journal.allClueDetails[i].Selected);
        }

    }
    
    
}
