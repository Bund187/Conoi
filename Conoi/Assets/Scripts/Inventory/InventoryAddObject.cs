using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class InventoryAddObject : MonoBehaviour
{
    public Image prefab;
    public Sprite box;

    int xPosition;

    public void AddObject(Sprite objSprite)
    {
        
        Image childObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        Text candyNumber =childObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();

        if (objSprite.name != "Candy")
            CreateImage(childObject, objSprite);
        else
        {
            for(int i = 0; i < transform.childCount; i++)
                if (transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite.name=="Candy")
                    candyNumber= transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>();
            
            if (candyNumber.text == "")
            {
                CreateImage(childObject, objSprite);
                candyNumber.text = "1";
            }
            else
            {
                candyNumber.text = (int.Parse(candyNumber.text)+1).ToString();
                Destroy(childObject);
            }
        }

        if (transform.childCount == 1)
            {
                childObject.rectTransform.anchoredPosition = new Vector2(0, -100);
                xPosition = 0;
            }
            else
            {
                xPosition -= 170;
                childObject.rectTransform.anchoredPosition = new Vector2(xPosition, -125);
            }
            transform.GetComponent<InventoryNavigation>().GetSlotsAndPositions();
    }

    void CreateImage(Image childObject, Sprite objSprite)
    {
        childObject.transform.SetParent(transform, false);
        childObject.GetComponent<Image>().sprite = box;
        childObject.transform.GetChild(0).GetComponent<Image>().sprite = objSprite;
        childObject.transform.GetChild(0).GetComponent<Image>().SetNativeSize();

        childObject.transform.SetSiblingIndex(0);
        childObject.GetComponent<RectTransform>().localScale = new Vector3(5, 5, 5);
    }
       
    

}
