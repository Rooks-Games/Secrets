using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    public JournalManager journal;
    public GameObject MainJournalBG;
    
    //TODO: A List for each NPCs Clues
    
    private void OnEnable()
    {
        MainJournalBG = gameObject.GetComponentInParent<RectTransform>().gameObject;
        journal = GameObject.Find("Journal Manager").GetComponent<JournalManager>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
