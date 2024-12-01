using System.Collections.Generic;
using Scripts.Map;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private HUDController _hudController;
        private List<InteractableObject> _currentInteractableObjects;
    
        public InteractableObject GetInteractionObject()
        {
            if (_currentInteractableObjects.Count == 0)
            {
                return null;
            }
        
            return _currentInteractableObjects[^1];
        }
    
        private void Start()
        {
            _currentInteractableObjects = new List<InteractableObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out InteractableObject interactableObject))
            {
                _currentInteractableObjects.Add(interactableObject);
                _hudController.SetInteractionUI(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out InteractableObject interactableObject))
            {
                _currentInteractableObjects.Remove(interactableObject);
                _hudController.SetInteractionUI(_currentInteractableObjects.Count > 0);
            }
        }
    }
}