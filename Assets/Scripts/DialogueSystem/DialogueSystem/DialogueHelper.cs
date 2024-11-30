namespace Scripts.DialogueSystem
{
    public enum Conditions
    {
        Confront,
        CheckLoyalty
    }
    
    public enum Actions
    {
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
            return true;
        }
        
        public void PerformActionForDialogueEntry(DialogueEntry dialogueEntry)
        {
        }
    }
}
