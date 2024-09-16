using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<ItemObj> itemList; public List<ItemObj> ItemListGet
    { get { return itemList; } }
    public void ItemListAdd(ItemObj item)
    { 
            itemList.Add(item);
            ItemUpdate();
    }

    #region References
    public static ItemManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        ItemUpdate();
    }

    private void ItemUpdate()
    {
        for(int i  = 0; i < itemList.Count; i++) 
        {
            if (itemList[i] == null) continue;
            UIManager.instance.inventorySlotList[i].sprite = itemList[i].sprite;
        }
    }
}
