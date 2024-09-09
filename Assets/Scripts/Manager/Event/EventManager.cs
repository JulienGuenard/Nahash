using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    EventObj eventCurrent; public EventObj EventCurrent
    { 
        get { return eventCurrent; } 
        set 
        { 
            eventCurrent = value;
            DialogManager.instance.DialogStart();
        }
    }

    #region References
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
