using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipData : MonoBehaviour
{
    public TooltipObj tooltipObj;

    public void OnMouseEnter()
    {
        TooltipManager.instance.Btn_ShowTooltip(tooltipObj.title, tooltipObj.text);
    }

    public void OnMouseExit()
    {
        TooltipManager.instance.HideTooltips();
    }
}
