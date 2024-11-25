using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    //Keep Info about the currently clicked tab
    public JournalState currJournalState = JournalState.NPC;
    
    public Button NPC_btn, Clue_btn;
    
    List<UIScreen> allScreens = new List<UIScreen>();
    
    Stack<UIScreen> UIScreenStack = new Stack<UIScreen>();

    public void AddToUIStack(UIScreen uiScreen)
    {
        UIScreenStack.Push(uiScreen);
    }

    public void RemoveFromUIStack(UIScreen uiScreen)
    {
        UIScreenStack.Pop();
    }

    public void AddToAllScreens(UIScreen uiScreen)
    {
        allScreens.Add(uiScreen);
    }
    
    public void SetButtonAsPerCurrJournalState()
    {
        RectTransform NPCRectTransform = NPC_btn.GetComponent<RectTransform>();
        RectTransform ClueRectTransform = Clue_btn.GetComponent<RectTransform>();
        int height = 135, smallWidth = 145, largeWidth = 180;
        
        if (currJournalState == JournalState.NPC)
        {
            Debug.Log("Setting up NPC Journal State!");
            NPCRectTransform.sizeDelta = new Vector2(largeWidth, height);
            ClueRectTransform.sizeDelta = new Vector2(smallWidth, height);
        }
        else
        {
            Debug.Log("Setting up Clue Journal State!");
            NPCRectTransform.sizeDelta = new Vector2(smallWidth, height);
            ClueRectTransform.sizeDelta = new Vector2(largeWidth, height);
        }
    }

    public void SetJournalState(int state)
    {
        Debug.Log("State Value: " + state);
        switch( (JournalState)state ) // use upcast, where 0 - first, 1 - second...
        {
            case(JournalState.NPC):
                currJournalState = JournalState.NPC;
                break;
            case(JournalState.Clue):
                currJournalState = JournalState.Clue;
                break;
        }
        Debug.Log("Curr Enum: " + currJournalState);
        SetButtonAsPerCurrJournalState();
    }
}

[Serializable]
public enum JournalState
{
    NPC, Clue
}
