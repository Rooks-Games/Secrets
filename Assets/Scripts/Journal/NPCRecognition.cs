using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPCRecognition : MonoBehaviour
{
    [SerializeField] Button thisNPC;
    public Image charImage;
    public TMP_Text charName;
    
    public NpcList npcType;

    public void BtnAddListener(UnityAction btnAction)
    {
        gameObject.name = Enum.GetName(typeof(NpcList), npcType) ?? string.Empty;
        thisNPC.onClick.AddListener(btnAction);
    }

    public void ClearThisBtnListeners()
    {
        thisNPC.onClick.RemoveAllListeners();
    }
    
}
