using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public Canvas canvas;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;        
    }

    public void DisplaySpeechBubble()
    {
        canvas.enabled = true;
    }

    public void HideSpeechBubble()
    {
        canvas.enabled = true;
    }

    public void SetText(string speechBubbleText)
    {
        text.text = speechBubbleText;
    }
}
