using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ButtonInput : MonoBehaviour
{
    public GameObject sceneToGo;
    public EventObj eventNext;

    private void OnMouseDown()
    {
        if (sceneToGo != null) GMBSceneManager.instance.SceneCurrent = sceneToGo;
        if (eventNext != null) EventManager.instance.EventCurrent = eventNext;
    }
}
