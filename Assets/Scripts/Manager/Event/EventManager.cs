using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject sceneEvent;
    public List<EventObj> mainEventList;
    public EventObj eventCurrent;

    #region References
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void EventStart(EventObj newEvent)
    {
        eventCurrent = newEvent;
        DialogManager.instance.DialogStart();
    }
}
