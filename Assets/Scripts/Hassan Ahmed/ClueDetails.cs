
using System;

[Serializable]
public class ClueDetails
{
    public string ClueName;
    public string ClueDescription;
    public NpcDetails BelongsTo = new NpcDetails();
    public bool FoundORNotFound = false;
}
