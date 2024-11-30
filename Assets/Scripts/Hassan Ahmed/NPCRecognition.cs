using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPCRecognition : MonoBehaviour
{
    Button thisNPC;
    public NpcList npcType;
    
    public Image charImage;
    public TMP_Text charName;

    // Start is called before the first frame update
    void Awake()
    {
        charImage = GetComponentInChildren<Image>();
        charName = GetComponentInChildren<TMP_Text>();
        
        thisNPC = GetComponent<Button>();
    }

    public void BtnAddListener(UnityAction btnAction)
    {
        thisNPC.onClick.AddListener(btnAction);
    }

    public void ClearThisBtnListeners()
    {
        thisNPC.onClick.RemoveAllListeners();
    }
    
}
