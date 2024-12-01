using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    
    //Keep Info about the currently clicked tab
    public JournalState currJournalState = JournalState.NPC;
    
    public Button NPC_btn, Clue_btn;
    
    public List<UIScreen> allScreens = new List<UIScreen>();
    
    Stack<UIScreen> UIScreenStack = new Stack<UIScreen>();
    
    public List<NpcDetails> allNpcDetails = new List<NpcDetails>();
    public List<ClueDetails> allClueDetails = new List<ClueDetails>();

    public NpcDetails selectedNpc;
    public bool ActivateClueWithPlus = false;

    public Image PopupImage;
    public TMP_Text PopupText;

    private float colorAlphaVal = 1.0f;

    public void PopupHandler(string text)
    {
        PopupImage.gameObject.SetActive(true);
        PopupText.text = text;
        StartCoroutine(PopUIFadeInOut());
    }
    
    private IEnumerator PopUIFadeInOut()
    {
        while (colorAlphaVal > 0.5f)
        {
            PopupImage.color = new Color(1, 1, 1, colorAlphaVal);
            PopupText.color = new Color(1, 1, 1, colorAlphaVal);
            yield return new WaitForSeconds(.33f);
            colorAlphaVal -= .16f;
        }
        PopupImage.color = new Color(1, 1, 1, 1.0f);
        PopupText.color = new Color(0, 0, 0, 1.0f);
        PopupImage.gameObject.SetActive(false);
    }


    public void ActivateNPCIconPage(UIScreen objScreen)
    {
        AddToUIStack(objScreen);
    }
    
    public void AddToUIStack(UIScreen uiScreen)
    {
        if(UIScreenStack.Count > 0)
            UIScreenStack.Peek().Deactivate();
        UIScreenStack.Push(uiScreen);
        uiScreen.Activate();
    }

    public void RemoveFromUIStack()
    {
        UIScreenStack.Pop().Deactivate();
        UIScreenStack.Peek().Activate();
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
            ActivateClueWithPlus = false;
            AddToUIStack(allScreens[0]);
            //allScreens[0].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Setting up Clue Journal State!");
            NPCRectTransform.sizeDelta = new Vector2(smallWidth, height);
            ClueRectTransform.sizeDelta = new Vector2(largeWidth, height);
            AddToUIStack(allScreens[1]);
            //allScreens[1].gameObject.SetActive(true);
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
