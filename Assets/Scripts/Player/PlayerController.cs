using Scripts.Map;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInteraction _playerInteractionProvider;
        [SerializeField] private Rigidbody2D _myRigidBody;
        private float _movementSpeed;
        private Vector2 _movement;
        private bool _isInDialogue;

        private void Update()
        {
            if (_isInDialogue)
            {
                return;
            }

            _movement = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                _movement += Vector2.up;
            }

            if (Input.GetKey(KeyCode.A))
            {
                _movement += Vector2.left;
            }

            if (Input.GetKey(KeyCode.S))
            {
                _movement += Vector2.down;
            }

            if (Input.GetKey(KeyCode.D))
            {
                _movement += Vector2.right;
            }

            if (Input.GetKey(KeyCode.E))
            {
                Interact();
            }

            _myRigidBody.AddForce(_movement * _movementSpeed);
        }

        public void Interact()
        {
            InteractableObject interactableObject = _playerInteractionProvider.GetInteractionObject();
            if (interactableObject == null)
            {
                return;
            }

            switch (interactableObject.Type)
            {
                case InteractableObjectType.Npc:
                    //Start Dialogue
                    break;
                case InteractableObjectType.Clue:
                    //Add Clue To 
                    break;
            }
        }
    }
}
