using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public InventoryAddObject invAddObjt;
    public Sprite objSprite;
    public RuntimeAnimatorController takenAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.GetChild(1).GetComponent<Animator>().runtimeAnimatorController = takenAnimator;
            invAddObjt.AddObject(objSprite);
            Destroy(gameObject);
        }
    }
}
