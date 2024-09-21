using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Compass compass;

    private QuestObj questCurrent;  public QuestObj QuestCurrent
    { 
        get { return questCurrent; } 
        set 
        { 
            questCurrent = value;
            compass.townNext = TownManager.instance.TownFind(value.townNext);
        }
    }

    #region References
    public static QuestManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
