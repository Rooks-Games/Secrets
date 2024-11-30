
using System;
using System.Collections.Generic;
using UnityEngine.UI;

[Serializable]
public class NpcDetails
{
    public string NpcName;
    public Image NpcIcon;
    public string NpcDescription;

    public List<ClueDetails> CorrectClues = new();
    public List<ClueDetails> AddedClues = new();

    //Loyalty = 0 = neutral
    //Loyalty  = 1 = Loyal To Us
    //Loyalty = -1 = Not Loyal To Us
    public int Loyalty = 0;
    
    public NpcList NpcIdentifier;
}
