using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMerchant : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWavingAnimation()
    {
        animator.SetTrigger("WavingTrigger");
    }

    public void PlayTalkingAnimation()
    {
        animator.SetTrigger("TalkingTrigger");
    }

    public void OnMouseDown()
    {
        PlayWavingAnimation();
    }
}
