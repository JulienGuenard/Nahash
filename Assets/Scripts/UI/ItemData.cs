using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    private ItemObj itemObj;  public ItemObj ItemObj
    { 
        get { return itemObj; } 
        set 
        { 
            itemObj = value;
            if (spriteR == null) spriteR = GetComponentInChildren<SpriteRenderer>();
            spriteR.sprite = itemObj.sprite;
        }
    }
    private SpriteRenderer spriteR;
}
