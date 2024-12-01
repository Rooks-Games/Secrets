using UnityEngine;

namespace Scripts.Map
{
    public enum InteractableObjectType
    {
        Undefined,
        Npc,
        Clue
    }

    public class InteractableObject : MonoBehaviour
    {
        public InteractableObjectType Type;
    }
}
