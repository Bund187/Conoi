using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryNavigation : MonoBehaviour
{
    public GameObject enterKey;
    public UseItemsData itemsData;
    public PlayerController playerControllerScript;

    private List <GameObject> slots = new List<GameObject>();
    private List<Vector2> positions = new List<Vector2>();
    private int positionOk;
    private bool locked;
    private Color white;
    private Color grey;
    private GameObject npc;

    private void Start()
    {
        white= new Color(1, 1,1);
        grey = new Color(0.5f, 0.5f, 0.5f);
        GetSlotsAndPositions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && enterKey.activeSelf)
        {
            int amount;
            if (slots[transform.childCount - 1].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text!="")
                amount = int.Parse(slots[transform.childCount - 1].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text);
            else
                amount = 0;
            
            gameObject.SetActive(npc.GetComponent<NpcAction>().NpcItemsList(transform.GetChild(transform.childCount - 1).transform.GetChild(0).GetComponent<Image>().sprite.name, npc.name, amount, slots[transform.childCount - 1]));
            playerControllerScript.ToggleInventory();
        }

        if (!locked)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                locked = true;
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    if (i != 0)
                    {
                        ChangeColor(i, grey);
                        StartCoroutine(Move(i, positions[i - 1]));
                    }
                    else
                    {
                        ChangeColor(i, white);
                        MoveToFirst(i, positions[transform.childCount - 1]);
                    }
                }
                ChangeColor(transform.childCount - 1, white);
                ReorderSlots(0, transform.childCount - 1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                locked = true;
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (i != transform.childCount - 1)
                    {
                        ChangeColor(i, grey);
                        StartCoroutine(Move(i, positions[i + 1]));
                    }
                    else
                    {
                        ChangeColor(i, white);
                        MoveToFirst(i, positions[0]);
                    }
                }
                ReorderSlots(transform.childCount - 1, 0);
                ChangeColor(transform.childCount - 1, white);
            }
        }
        if(positionOk== transform.childCount)
            GetSlotsAndPositions();
        
    }

    public void GetSlotsAndPositions()
    {
        positionOk = 0;
        slots.Clear();
        positions.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            slots.Add(transform.GetChild(i).gameObject);
            positions.Add(transform.GetChild(i).localPosition);
            
            if(i== transform.childCount-1)
                ChangeColor(i, white);
            else
                ChangeColor(i, grey);
        }
        locked = false;
    }

    public void ChangeColor(int pos, Color color)
    {
        transform.GetChild(pos).GetComponent<Image>().color = color;
        transform.GetChild(pos).GetChild(0).GetComponent<Image>().color = color;
    }

    public void ReorderSlots(int start, int end)
    {
        slots[start].transform.SetSiblingIndex(end);
    }
   
    IEnumerator Move(int from, Vector2 to)
    {
        while (!Mathf.Approximately(slots[from].transform.localPosition.x, to.x))
        {
            slots[from].transform.localPosition = Vector2.MoveTowards(slots[from].transform.localPosition, new Vector2(to.x, slots[from].transform.localPosition.y), 20);
            yield return true;
        }
        slots[from].transform.localPosition = to;
        positionOk++;
    }

    void MoveToFirst(int from, Vector2 to)
    {
        slots[from].transform.localPosition = to;
        positionOk++;
    }

    public GameObject Npc { get => npc; set => npc = value; }
}
