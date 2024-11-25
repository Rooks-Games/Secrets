using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueUI : UIScreen
{
    public JournalManager journal;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        journal.currJournalState = JournalState.Clue;
    }
}
