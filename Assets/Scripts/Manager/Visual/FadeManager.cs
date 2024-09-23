using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    enum FadeFrom { Next, SceneButton }

    public Animator fade;

    private SceneName sceneToGo;
    private SceneHeroName sceneHeroToGo;
    private EventObj eventNext;

    #region References
    public static FadeManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void Btn_FadeScene(SceneName sceneN, SceneHeroName sceneHN, EventObj evtNext)
    {
        sceneToGo = sceneN;
        sceneHeroToGo = sceneHN;
        eventNext = evtNext;

        StartCoroutine(Fade(FadeFrom.SceneButton));
    }
    public void NextBtn_FadeEvent(float time)
    {
        EvtSceneManager.instance.CanPlayerGoNext = false;
        StartCoroutine(Fade(FadeFrom.Next));
    }

    private IEnumerator Fade(FadeFrom fadeFrom)
    {
                                                Fade_InStart(fadeFrom);
        yield return new WaitForSeconds(1f);    Fade_InEnd(fadeFrom);
        yield return new WaitForSeconds(0.1f);  Fade_OutStart(fadeFrom);
        yield return new WaitForSeconds(1f);    Fade_OutEnd(fadeFrom);
    }
    private void Fade_InStart(FadeFrom fadeFrom)
    {
        InputManager.instance.InputDisable();
        fade.SetBool("FadeIn", true);
    }
    private void Fade_InEnd(FadeFrom fadeFrom)
    {
        if (fadeFrom == FadeFrom.Next) Fade_NextEvent();
        fade.SetBool("FadeIn", false);
    }
    private void Fade_OutStart(FadeFrom fadeFrom)
    {
        if (fadeFrom == FadeFrom.SceneButton) Fade_NextScene();
        fade.SetBool("FadeOut", true);
    }
    private void Fade_OutEnd(FadeFrom fadeFrom)
    {
        fade.SetBool("FadeOut", false);

        if (fadeFrom == FadeFrom.Next) EvtSceneManager.instance.CanPlayerGoNext = true;
        InputManager.instance.InputEnable();
    }

    private void Fade_NextEvent()
    {
        EvtSceneManager.instance.Next();
    }
    private void Fade_NextScene()
    {
        if (sceneToGo != SceneName.None) InputManager.instance.SceneNew(sceneToGo, eventNext);
        if (sceneHeroToGo != SceneHeroName.None) InputManager.instance.SceneHeroNew(sceneHeroToGo);
    }
}
