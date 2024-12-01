namespace Scripts.DialogueSystem
{
    public enum Conditions
    {
        Undefined,
        CanConfront,
        Confront,
        CheckLoyalty,
        IsLoyal,
        IsNotLoyal,
        IsNeutral
    }
    
    public enum Actions
    {
        Undefined,
        SetLoyalty
    }
    
    public class DialogueHelper
    {
        private DialogueDependencies _dependencies;

        public DialogueHelper(DialogueDependencies dialogueDependencies)
        {
            _dependencies = dialogueDependencies;
        }

        public bool CheckConditionForDialogueEntry(DialogueEntry dialogueEntry)
        {
            switch (dialogueEntry.Conditions)
            {
                case Conditions.IsLoyal:
                    return _dependencies.NpcDataProvider.NpcsData[dialogueEntry.NpcId].Loyalty == 1;
                    break;
                case Conditions.IsNotLoyal:
                    return _dependencies.NpcDataProvider.NpcsData[dialogueEntry.NpcId].Loyalty == -1;
                    break;
                case Conditions.IsNeutral:
                    return _dependencies.NpcDataProvider.NpcsData[dialogueEntry.NpcId].Loyalty == 0;
                    break;
                case Conditions.CanConfront:
                    return _dependencies.ConfrontNPC.CanConfront(dialogueEntry.NpcId);
                    break;
                case Conditions.Confront:
                    return _dependencies.ConfrontNPC.Confront(dialogueEntry.NpcId);
                    break;
            }
            return true;
        }
        
        public void PerformActionForDialogueEntry(DialogueEntry dialogueEntry)
        {
        }
    }
}
