using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StoreMerchant : MonoBehaviour
{
    public StoreCounter storeCounter;
    private Animator animator;
    private SpeechBubble speechBubble;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        speechBubble = GetComponent<SpeechBubble>();
    }

    private void PlayWavingAnimation()
    {
        animator.SetTrigger("WavingTrigger");
    }

    public void PlayTalkingAnimation()
    {
        animator.SetTrigger("TalkingTrigger");
    }

    public void DisplaySpeechBubble()
    {
        speechBubble.DisplaySpeechBubble();
    }

    public void OnMouseDown()
    {
        PlayWavingAnimation();
    }

    private string BuildBalanceText()
    {
        Dictionary<Item, int> itemCounts = storeCounter.GetDistinctItemCounts();
        if (itemCounts.Count == 0)
            return System.String.Empty;

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("YOU HAVE ");
        
        
        KeyValuePair<Item, int> lastKeyValue = itemCounts.Last();

        foreach (KeyValuePair<Item, int> keyValuePair in itemCounts)
        {
            stringBuilder.Append(keyValuePair.Value + " " + keyValuePair.Key.name);

            if (!keyValuePair.Equals(lastKeyValue))
            {
                stringBuilder.Append(", ");
            }
        }

        stringBuilder.Append(". THE TOTAL IS $");
        stringBuilder.Append(storeCounter.GetTotal());
        return stringBuilder.ToString();
    }

    public void SetSpeechBubbleText()
    {
        speechBubble.SetText(BuildBalanceText());
    }
}
