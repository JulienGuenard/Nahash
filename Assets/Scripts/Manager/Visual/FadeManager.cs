using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public Animator fade;
    #region References
    public static FadeManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void FadeNormal(SceneName sceneToGo, SceneHeroName sceneHeroToGo, EventObj eventNext)
    {
        StartCoroutine(Fade(sceneToGo, sceneHeroToGo, eventNext));
    }
    public void Next_IsFade(float time)
    {
        StartCoroutine(Next_IsFadeDelay(time));
    }

    public IEnumerator Next_IsFadeDelay(float time)
    {
        InputManager.instance.InputDisable();
        EvtSceneManager.instance.CanPlayerGoNext = false;
        fade.SetBool("FadeIn", true);
        yield return new WaitForSeconds(1f);
        EvtSceneManager.instance.Next();
        fade.SetBool("FadeIn", false);
        yield return new WaitForSeconds(time);
        fade.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1f);
        fade.SetBool("FadeOut", false);
        EvtSceneManager.instance.CanPlayerGoNext = true;
        InputManager.instance.InputEnable();
    }

    IEnumerator Fade(SceneName sceneToGo, SceneHeroName sceneHeroToGo, EventObj eventNext)
    {
        InputManager.instance.InputDisable();
        fade.SetBool("FadeIn", true);
        yield return new WaitForSeconds(1f);
        fade.SetBool("FadeIn", false);
        yield return new WaitForSeconds(0.1f);
        if (sceneToGo != SceneName.None)            InputManager.instance.SceneNew(sceneToGo, eventNext);
        if (sceneHeroToGo != SceneHeroName.None)    InputManager.instance.SceneHeroNew(sceneHeroToGo);
        fade.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1f);
        fade.SetBool("FadeOut", false);
        InputManager.instance.InputEnable();
    }
}
