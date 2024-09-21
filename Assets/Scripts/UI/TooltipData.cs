using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipData : MonoBehaviour
{
    public TooltipObj tooltipObj;
    private ItemData itemData;

    private void OnEnable()
    {
        itemData = GetComponent<ItemData>();
    }

    public void OnMouseEnter()
    {
        if (itemData != null) TooltipManager.instance.Btn_ShowTooltip(itemData.ItemObj.itemName, itemData.ItemObj.description);
        if (tooltipObj != null) TooltipManager.instance.Btn_ShowTooltip(tooltipObj.title, tooltipObj.text);
    }

    public void OnMouseExit()
    {
        TooltipManager.instance.HideTooltips();
    }
}
