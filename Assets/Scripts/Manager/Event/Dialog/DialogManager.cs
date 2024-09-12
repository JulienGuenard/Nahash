using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    #region References
    public static DialogManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void DialogEnable()
    {

    }
    public void DialogDisable()
    {

    }
}
