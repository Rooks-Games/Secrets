namespace Scripts.Map
{
    public class InteractableClue : InteractableObject
    {
        public string Id;
        
        private void Start()
        {
            Type = InteractableObjectType.Clue;
        }
    }
}