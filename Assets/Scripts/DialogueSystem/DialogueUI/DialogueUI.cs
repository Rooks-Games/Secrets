using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.DialogueSystem
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _dialogueText;
        [SerializeField] private Image _speakerImage;
        private DialogueDependencies _dependencies;

        public void Init(DialogueDependencies dialogueDependencies)
        {
            _dependencies = dialogueDependencies;
        }

        public void ShowDialogue(string dialogue)
        {
            gameObject.SetActive(true);
        }
        
        public void EndDialogue()
        {
            gameObject.SetActive(false);
        }
    }
}
