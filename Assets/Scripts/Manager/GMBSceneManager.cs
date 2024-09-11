using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMBSceneManager : MonoBehaviour
{
    public List<GameObject> sceneList;
    public List<GameObject> sceneHeroList;

    GameObject sceneCurrent;    public GameObject SceneCurrent
    { 
        get { return sceneCurrent; } 
        set 
        {
            if (sceneCurrent != null)   SceneLast = sceneCurrent;

            sceneCurrent = value;
            sceneCurrent.SetActive(true);
            SceneCurrent_Change();
        }
    }
    GameObject sceneLast;       public GameObject SceneLast
    {
        get { return sceneLast; }
        set
        {
            sceneLast = value;
            sceneLast.SetActive(false);
            SceneLast_Change();
        }
    }
    SceneName sceneNameCurrent; public SceneName SceneNameCurrent
    {
        get { return sceneNameCurrent; }
        set
        {
            if (value == SceneName.None) return;

            sceneNameCurrent = value;

            switch (sceneNameCurrent)
            {
                case SceneName.Accueil:     SceneCurrent = sceneList[0]; break;
                case SceneName.Event:       SceneCurrent = sceneList[1]; break;
                case SceneName.Hero:        SceneCurrent = sceneList[2]; break;
                case SceneName.Town:        SceneCurrent = sceneList[3]; break;
                case SceneName.Worldmap:    SceneCurrent = sceneList[4]; break;
                case SceneName.Last:        SceneCurrent = SceneLast; break;
            }
        }
    }

    GameObject sceneHeroCurrent; public GameObject SceneHeroCurrent
    {
        get { return sceneHeroCurrent; }
        set
        {
            if (sceneHeroCurrent != null) SceneHeroLast = sceneHeroCurrent;

            sceneHeroCurrent = value;
            sceneHeroCurrent.SetActive(true);
        }
    }
    GameObject sceneHeroLast; public GameObject SceneHeroLast
    {
        get { return sceneHeroLast; }
        set
        {
            sceneHeroLast = value;
            sceneHeroLast.SetActive(false);
        }
    }
    SceneHeroName sceneNameHeroCurrent; public SceneHeroName SceneHeroNameCurrent
    {
        get { return sceneNameHeroCurrent; }
        set
        {
            if (value == SceneHeroName.None) return;

            sceneNameHeroCurrent = value;

            switch (sceneNameHeroCurrent)
            {
                case SceneHeroName.Inventory: SceneHeroCurrent = sceneHeroList[0]; break;
                case SceneHeroName.Skilltree: SceneHeroCurrent = sceneHeroList[1]; break;
            }
        }
    }

    #region References
    public static GMBSceneManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        Start_SceneStart();
        Start_SceneHeroStart();
    }

    private void Start_SceneStart()
    {
        foreach (GameObject scene in sceneList)
        {
            if (scene.activeInHierarchy) { SceneCurrent = scene; break; }
        }
    }
    private void SceneCurrent_Change()
    {
        CameraManager.instance.CameraChange(sceneCurrent.name);

        if (sceneCurrent.name == "SceneWorldmap") WorldmapManager.instance.WorldmapEnable();
        if (sceneCurrent.name == "SceneEvent") DialogManager.instance.CanPlayerPressDialogNext = true;
    }
    private void SceneLast_Change()
    {
        if (sceneLast.name == "SceneWorldmap")  WorldmapManager.instance.WorldmapDisable();
        if (sceneLast.name == "SceneEvent")     DialogManager.instance.CanPlayerPressDialogNext = false;
    }

    private void Start_SceneHeroStart()
    {
        SceneHeroCurrent = sceneHeroList[0];
    }
}
