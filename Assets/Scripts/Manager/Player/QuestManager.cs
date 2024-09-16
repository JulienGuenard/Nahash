using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    #region References
    public static QuestManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
