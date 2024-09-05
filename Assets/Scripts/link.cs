using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using static Unity.Burst.Intrinsics.X86.Avx;

public class link : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    private TextMeshProUGUI tmp;
    string lastStringHover = " ";
    string lastStringChanged = " ";

    public void OnPointerMove(PointerEventData eventData)
    {
        tmp = GetComponent<TextMeshProUGUI>();

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(tmp, Input.mousePosition, null);
        Debug.Log(linkIndex);

        if (linkIndex != 1)
        {
            string newString = tmp.text.Replace(lastStringChanged, lastStringHover);
            tmp.text = newString;
        }
        else
        {
            string linkId = tmp.textInfo.linkInfo[linkIndex].GetLinkID();

            if (linkId != "ID") return;

            string word = tmp.textInfo.linkInfo[linkIndex].GetLinkText();

            if (lastStringChanged == word) return;

            lastStringHover = word;
            lastStringChanged = "click";

            string newString = tmp.text.Replace(lastStringHover, lastStringChanged);
            tmp.text = newString;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}