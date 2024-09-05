using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshPro scoreTxt;

    #region References
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
