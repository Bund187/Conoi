using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GekkoManager : MonoBehaviour
{

    public GameObject[] gekkoBushes;
    public Sprite gekko;

    private void OnTriggerExit2D(Collider2D collision)
    {
        int rnd = Random.Range(0, gekkoBushes.Length - 1);
        gekkoBushes[rnd].GetComponent<SpriteRenderer>().sprite = gekko;
        print("Rnd " + gekkoBushes[rnd].name);
    }
}
