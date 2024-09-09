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
            if (sceneCurrent != null)   SceneLast = sceneCurrent;
            if (sceneLast != null)      sceneLast.SetActive(false);

            sceneCurrent = value;
            sceneCurrent.SetActive(true);
            CameraManager.instance.CameraChange(sceneCurrent.name);
            GameManager.instance.SceneChangeManager(sceneCurrent.name, true);
        }
    }
    GameObject sceneLast; public GameObject SceneLast
    {
        get { return sceneLast; }
        set
        {
            sceneLast = value;
            GameManager.instance.SceneChangeManager(sceneLast.name, false);
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
        SceneStart();
    }

    private void SceneStart()
    {
        foreach (GameObject scene in sceneList)
        {
            if (scene.activeInHierarchy) { SceneCurrent = scene; break; }
        }
    }
}
