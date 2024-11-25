using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPCRecognition : MonoBehaviour
{
    Button thisNPC;
    public NpcList npcType;
    // Start is called before the first frame update
    void Start()
    {
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
