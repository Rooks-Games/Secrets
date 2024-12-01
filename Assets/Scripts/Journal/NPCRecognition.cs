using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Npcs;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPCRecognition : MonoBehaviour
{
    [SerializeField] Button thisNPC;
    public Image charImage;
    public TMP_Text charName;
    
    public NpcId npcType;

    public void BtnAddListener(UnityAction btnAction)
    {
        gameObject.name = Enum.GetName(typeof(NpcId), npcType) ?? string.Empty;
        thisNPC.onClick.AddListener(btnAction);
    }

    public void ClearThisBtnListeners()
    {
        thisNPC.onClick.RemoveAllListeners();
    }
    
}
