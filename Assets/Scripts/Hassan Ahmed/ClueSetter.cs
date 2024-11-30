using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class ClueSetter : UIScreen
{
    [SerializeField] private TMP_Text clueName;
    [SerializeField] private TMP_Text clueDescription;
    
    [SerializeField] Image questionMarkImage;
    [SerializeField] private Button cluePageButton;
    
    public void ClueSetterOnNPCPage(ClueDetails currentClueDetails)
    {
        questionMarkImage.gameObject.SetActive(false);
        clueName.text = currentClueDetails.ClueName;
    }

    public void ClueSetterOnCluePage(ClueDetails currentClueDetails)
    {
        clueName.text = currentClueDetails.ClueName;
        clueDescription.text = currentClueDetails.ClueDescription;
    }
}
