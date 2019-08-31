using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemsData : MonoBehaviour
{
    public FishAction fishAction;

    public void NpcItemsList(string item, string npc, int amount)
    {
        if(item=="candy" && npc == "Fish" && amount==0)
        {
            fishAction.PerformAction();
        }

    }
}
