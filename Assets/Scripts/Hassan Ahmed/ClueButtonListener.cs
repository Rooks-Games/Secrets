using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClueButtonListener : MonoBehaviour
{
    [SerializeField] Button thisClueButton;
    [SerializeField] TMP_Text thisText;
    [SerializeField] private GameObject QuestionMark;

    // Start is called before the first frame update
    void Awake()
    {
        thisClueButton = GetComponent<Button>();
    }

    public void BtnAddListener(UnityAction btnAction)
    {
        thisClueButton.onClick.AddListener(btnAction);
    }

    public void ClueFound(ClueDetails clueDetails)
    {
        QuestionMark.SetActive(false);
        thisText.gameObject.SetActive(true);
        thisClueButton.interactable = true;
        SetClueButtonText(clueDetails.ClueName);
    }
    public void ClueNotFound()
    {
        QuestionMark.SetActive(true);
        thisText.gameObject.SetActive(false);
        thisClueButton.interactable = false;
    }

    public void ClueSelectedState(bool isSelected)
    {
        thisClueButton.interactable = !isSelected;
    }
    
    public void SetClueButtonText(string text)
    {
        thisText.text = text;
    }

    public void ClearThisBtnListeners()
    {
        thisClueButton.onClick.RemoveAllListeners();
    }
}
