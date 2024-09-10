using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public SceneName sceneToGo;
    public SceneHeroName sceneHeroToGo;
    public EventObj eventNext;
    public TownObj townNext;

    private void OnMouseDown()
    {
                                GMBSceneManager.instance.SceneNameCurrent = sceneToGo;
                                GMBSceneManager.instance.SceneHeroNameCurrent = sceneHeroToGo;
        if (eventNext != null)  EventManager.instance.EventCurrent = eventNext;
        if (townNext != null)   TownManager.instance.TownCurrent = townNext;
    }
}
