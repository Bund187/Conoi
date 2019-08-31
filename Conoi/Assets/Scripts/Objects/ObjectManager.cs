using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public InventoryAddObject invAddObjt;
    public Sprite objSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            invAddObjt.AddObject(objSprite);
            Destroy(gameObject);
        }
    }
}
