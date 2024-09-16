using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public GameObject tooltipGMB;
    public TextMeshPro tooltipGMB_title, tooltipGMB_text;

    #region instance
    public static TooltipManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    public void Btn_ShowTooltip(string title, string text)
    {
        HideTooltips();
        ShowTooltip(title, text, tooltipGMB, tooltipGMB_title, tooltipGMB_text);

    }
    public void HideTooltips()
    {
        tooltipGMB.SetActive(false);
    }

    private void ShowTooltip(string title, string text, GameObject gmb, TextMeshPro tooltipTitle, TextMeshPro tooltipText)
    {
        gmb.SetActive(true);
        tooltipTitle.text = title;
        tooltipText.text = text;
    }
}
