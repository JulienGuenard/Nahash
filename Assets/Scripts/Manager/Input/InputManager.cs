using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool playerCanInteract;

    #region References
    public static InputManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        InputEnable();
    }

    private void Update()
    {
        AxisInput();
        AnyInput();
    }

    public void InputEnable()
    {
        playerCanInteract = true;
    }
    public void InputDisable()
    {
        playerCanInteract = false;
    }

    public void ButtonInput(SceneName sceneToGo, SceneHeroName sceneHeroToGo, EventObj eventNext, FadeType fadeType = FadeType.None)
    {
        if (!playerCanInteract) return;

        if (fadeType == FadeType.Normal) FadeManager.instance.Btn_FadeScene(sceneToGo, sceneHeroToGo, eventNext);
        else
        {
            if (sceneToGo != SceneName.None) SceneNew(sceneToGo, eventNext);
            if (sceneHeroToGo != SceneHeroName.None) SceneHeroNew(sceneHeroToGo);
        }
    }
    public void NextInput()
    {
        if (!playerCanInteract) return;
        VoiceManager.instance.VoiceSpeedUp();
        if (!EvtSceneManager.instance.CanPlayerGoNext) return;

        EvtSceneManager.instance.Next();
    }

    private void AxisInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        SnakeManager.instance.Input_SnakeDirection(inputX, inputY);
    }
    private void AnyInput()
    {
        if (!Input.anyKeyDown || Input.GetKeyDown(KeyCode.Mouse0)) return;

        NextInput();
    }

    public void SceneNew(SceneName sceneToGo, EventObj eventNext)
    {
        GMBSceneManager.instance.SceneNameCurrent = sceneToGo;
        if (eventNext != null) EventManager.instance.EventCurrent = eventNext;
    }
    public void SceneHeroNew(SceneHeroName sceneHeroToGo)
    {
        GMBSceneManager.instance.SceneHeroNameCurrent = sceneHeroToGo;
    }
}
