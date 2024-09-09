using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public EventObj nextEvent;
    public GameObject sceneOn;

    private void OnMouseDown()
    {
        if (nextEvent != null) EventManager.instance.eventCurrent = nextEvent;
    }
}
