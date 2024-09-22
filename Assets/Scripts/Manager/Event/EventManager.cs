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
            EvtSceneManager.instance.EventCurrent = value;
            QuestManager.instance.QuestCheckEvent();
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
        EvtSceneManager.instance.EvtSceneEnable();
    }
    public void EventDisable()
    {
        EvtSceneManager.instance.EvtSceneDisable();
    }

    public void Worldmap_RandomEvent(List<EventObj> eventRNGList)
    {
        GMBSceneManager.instance.SceneNameCurrent = SceneName.Event;
        EventCurrent = eventRNGList[Random.Range(0, eventRNGList.Count)];
    }
}
