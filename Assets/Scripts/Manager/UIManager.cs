using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    TextMeshPro scoreTxt; public TextMeshPro ScoreTxt
    {
        get { return scoreTxt; }
        set { scoreTxt = value; }
    } // AutoEnabler
    TextMeshPro timeTxt; public TextMeshPro TimeTxt
    {
        get { return timeTxt; }
        set { timeTxt = value; }
    } // AutoEnabler
    TextMeshPro lifeTxt; public TextMeshPro LifeTxt
    {
        get { return lifeTxt; }
        set { lifeTxt = value; }
    } // AutoEnabler

    #region References
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
