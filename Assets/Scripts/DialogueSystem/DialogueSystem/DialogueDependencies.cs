using Scripts.Npcs;

namespace Scripts.DialogueSystem
{
    [System.Serializable]
    public class DialogueDependencies
    {
        public DialogueDatabase DialogueDatabase;
        public NpcDataProvider NpcDataProvider;
        public ConfrontNPC ConfrontNPC;
    }
}