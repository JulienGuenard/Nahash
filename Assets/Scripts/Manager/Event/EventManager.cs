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

    public void EventEnable()
    {
        DialogManager.instance.CanPlayerPressDialogNext = true;
    }
    public void EventDisable()
    {
        DialogManager.instance.CanPlayerPressDialogNext = false;
    }
    public void Worldmap_RandomEvent(List<EventObj> eventRNGList)
    {
        GMBSceneManager.instance.SceneNameCurrent = SceneName.Event;
        EventCurrent = eventRNGList[Random.Range(0, eventRNGList.Count)];
    }
}
