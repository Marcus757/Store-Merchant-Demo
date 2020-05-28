using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    public StoreMerchant storeMerchant;

    private void OnMouseDown()
    {
        if (storeMerchant.storeCounter.GetDistinctItemCounts().Count == 0)
            return;
        
        storeMerchant.SetSpeechBubbleText();
        storeMerchant.DisplaySpeechBubble();
        storeMerchant.PlayTalkingAnimation();
    }
}
