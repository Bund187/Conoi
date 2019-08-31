using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTalk : MonoBehaviour
{
    public GameObject bubble;
    public GameObject[] icons;
    public GameObject wrongItem;

    Animator anim, bubbleAnim;
    bool finishAnim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        bubbleAnim = bubble.GetComponent<Animator>();
    }

    private void Update()
    {
        if (bubble.activeSelf && Utils.AnimationIsFinished(bubbleAnim) && !finishAnim)
        {
            if(!wrongItem.activeSelf)
                ActivateIcons();
            finishAnim = true;
        }
        if (Utils.AnimationIsFinished(wrongItem.GetComponent<Animator>()))
        {
            ActivateIcons();
            wrongItem.SetActive(false);
        }
        
    }

    void ActivateIcons()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("isTalking", true);
            bubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < icons.Length; i++)
            {
                icons[i].SetActive(false);
            }
            if(wrongItem.activeSelf)
                wrongItem.SetActive(false);
            bubble.SetActive(false);
            anim.SetBool("isTalking", false);
            finishAnim = false;
        }
    }
}
