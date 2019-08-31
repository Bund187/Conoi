using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class NpcAction : MonoBehaviour
{
    public string thisItem, thisNpc;
    public int thisAmount;
    public GameObject[] icons;
    public GameObject wrongItem;

    public bool NpcItemsList(string item, string npc, int amount, GameObject goItem)
    {
        if (item == thisItem && npc == thisNpc && amount == thisAmount)
        {
            PerformAction();
            Destroy(goItem);
            return true;
        }
        else
        {
            WrongAction();
            return false;
        }

    }

    void WrongAction()
    {
        for(int i = 0; i < icons.Length; i++)
        {
            print("Desactivando objeto " + icons[i].name);
            icons[i].SetActive(false);
        }
        wrongItem.SetActive(true);
    }

    public abstract void PerformAction();
}
