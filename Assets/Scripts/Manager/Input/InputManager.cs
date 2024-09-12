using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region References
    public static InputManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Update()
    {
        AxisInput();
    }

    public void ButtonInput(SceneName sceneToGo, SceneHeroName sceneHeroToGo, EventObj eventNext)
    {
        if (sceneToGo != SceneName.None)            SceneNew(sceneToGo, eventNext);
        if (sceneHeroToGo != SceneHeroName.None)    SceneHeroNew(sceneHeroToGo);
    }

    private void AxisInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        SnakeManager.instance.Input_SnakeDirection(inputX, inputY);
    }

    private void SceneNew(SceneName sceneToGo, EventObj eventNext)
    {
        {
            GMBSceneManager.instance.SceneNameCurrent = sceneToGo;
            if (eventNext != null) EventManager.instance.EventCurrent = eventNext;
        }
    }
    private void SceneHeroNew(SceneHeroName sceneHeroToGo)
    {
         GMBSceneManager.instance.SceneHeroNameCurrent = sceneHeroToGo;
    }
}
