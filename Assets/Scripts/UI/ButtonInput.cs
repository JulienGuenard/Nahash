using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public SceneName sceneToGo;
    public SceneHeroName sceneHeroToGo;
    public EventObj eventNext;

    private void OnMouseDown()
    {
        InputManager.instance.ButtonInput(sceneToGo, sceneHeroToGo, eventNext);
    }
}
