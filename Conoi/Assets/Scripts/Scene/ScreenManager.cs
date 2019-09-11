using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public void ShowScreen(Sprite image, RuntimeAnimatorController animImage, Sprite imageText, RuntimeAnimatorController animImageText, Color color)
    {
        transform.GetChild(0).GetComponent<Image>().color = color;

        transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = image;
        transform.GetChild(0).GetChild(0).GetComponent<Animator>().runtimeAnimatorController = animImage;

        transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = imageText;
        transform.GetChild(0).GetChild(1).GetComponent<Animator>().runtimeAnimatorController = animImageText;

        transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(2).GetComponent<ResetGame>().enabled = true;
        
        gameObject.SetActive(true);
    }

    public void HideScreen()
    {
        gameObject.SetActive(false);
    }
}
