using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMBSceneManager : MonoBehaviour
{
    public List<GameObject> sceneList;
    GameObject sceneCurrent;

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

    private void StartingScene()
    {
        foreach (GameObject scene in sceneList)
        {
            if (scene.activeInHierarchy) { sceneCurrent = scene; break; }
        }
    }

    public void ChangeScene(GameObject sceneOn)
    {
        sceneCurrent.SetActive(false);
        sceneOn.SetActive(true);

        if (sceneOn.name == "SceneWorldmap")
        {
            Camera.main.orthographicSize = CameraManager.instance.camSizeWorldmap;
            Camera.main.transform.position = new Vector3(0, -2.73f, -10);
        }else
        {
            Camera.main.orthographicSize = CameraManager.instance.camSizeNormal;
            Camera.main.transform.position = new Vector3(0, 0, -10);
        }
    }
}
