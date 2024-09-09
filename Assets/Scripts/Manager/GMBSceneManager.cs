using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMBSceneManager : MonoBehaviour
{
    public List<GameObject> sceneList;
    GameObject sceneCurrent; public GameObject SceneCurrent
    { 
        get { return sceneCurrent; } 
        set 
        { 
            sceneCurrent = value;
            CameraManager.instance.ChangeCamera(sceneCurrent.name);
            SetScene(sceneCurrent.name, true);
        }
    }
    GameObject sceneLast; public GameObject SceneLast
    {
        get { return sceneLast; }
        set
        {
            sceneLast = value;
            SetScene(sceneLast.name, false);
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
        StartingScene();
    }

    public void ChangeScene(GameObject sceneOn, EventObj eventNext)
    {
        SceneLast = sceneCurrent;
        sceneCurrent.SetActive(false);
        SceneCurrent = sceneOn;
        sceneOn.SetActive(true);
    }

    private void StartingScene()
    {
        foreach (GameObject scene in sceneList)
        {
            if (scene.activeInHierarchy) { SceneCurrent = scene; break; }
        }
    }

    private void SetScene(string sceneName, bool state)
    {
        if (sceneName == "SceneWorldmap" && state) WorldmapManager.instance.WorldmapEnable();
        if (sceneName == "SceneWorldmap" && !state) WorldmapManager.instance.WorldmapDisable();
    }
}
