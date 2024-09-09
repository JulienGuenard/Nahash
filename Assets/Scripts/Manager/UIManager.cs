using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    TextMeshPro scoreTxt; [HideInInspector] public TextMeshPro ScoreTxt
    {
        get { return scoreTxt; }
        set { scoreTxt = value; }
    } // AutoEnabler

    #region References
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
