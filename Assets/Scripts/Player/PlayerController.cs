using System;
using Scripts.Map;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInteraction _playerInteractionProvider;
        [SerializeField] private Rigidbody2D _myRigidBody;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private Animator _animator;
        [SerializeField] private JournalManager _journalManager;
        [SerializeField] private DialogueSystem.DialogueSystem _dialogueSystem;
        private Vector2 _movement;
        private bool _isInDialogue;

        private void Awake()
        {
            _dialogueSystem.ConversationStarted += ConversationStarted;
            _dialogueSystem.ConversationEnded += ConversationEnded;
        }
        
        private void OnDestroy()
        {
            _dialogueSystem.ConversationStarted -= ConversationStarted;
            _dialogueSystem.ConversationEnded -= ConversationEnded;
        }

        private void ConversationStarted()
        {
            _isInDialogue = true;
        }
        
        private void ConversationEnded()
        {
            _isInDialogue = false;
        }

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

            if (_movement.magnitude>0)
            {
                _animator.SetTrigger("Walk");
            }
            else
            {
                _animator.SetTrigger("Idle");
            }

            if (_movement.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (_movement.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            _myRigidBody.AddForce(_movement.normalized * _movementSpeed);
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
                    _dialogueSystem.StartConversationWith(((InteractableNpc)interactableObject).Id);
                    break;
                case InteractableObjectType.Clue:
                    _journalManager.ClueFound(((InteractableClue)interactableObject).Id);
                    Destroy(interactableObject);
                    break;
            }
        }
    }
}
