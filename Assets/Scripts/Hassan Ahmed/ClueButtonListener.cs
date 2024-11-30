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

    // Start is called before the first frame update
    void Awake()
    {
        thisClueButton = GetComponent<Button>();
    }

    public void BtnAddListener(UnityAction btnAction)
    {
        thisClueButton.onClick.AddListener(btnAction);
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
