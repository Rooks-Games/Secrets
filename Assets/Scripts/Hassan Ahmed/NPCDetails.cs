
using System.Collections.Generic;
using UnityEngine.UI;

public class NpcDetails
{
    public string NpcName;
    public Image NpcIcon;
    public string NpcDescription;

    public List<ClueDetails> AttachedClues = new();

    public NpcList NpcIdentifier;
}
