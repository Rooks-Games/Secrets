using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.DialogueSystem
{
    public class DialoguePlayerOptionButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _dialogueText;
        [SerializeField] private Button _dialogueBox;
        private DialogueEntry _dialogueEntry;
        private Action<int> _optionClicked;
        
        public void Init(DialogueEntry dialogueEntry, Action<int> callback)
        {
            _dialogueEntry = dialogueEntry;
            _dialogueText.text = _dialogueEntry.DialogueText;
            _dialogueBox.onClick.AddListener(OptionSelected);
            _optionClicked = callback;
        }
        
        public void OptionSelected()
        {
            _optionClicked?.Invoke(_dialogueEntry.DialogueID);
        }
    }
}