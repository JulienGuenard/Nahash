using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float camSizeNormal;
    public float camSizeWorldmap;

    #region References
    public static CameraManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void ChangeCamera(string sceneName)
    {
        if (sceneName == "SceneWorldmap")
        {
            Camera.main.orthographicSize = camSizeWorldmap;
            Camera.main.transform.position = new Vector3(0, -2.73f, -10);
        }
        else
        {
            Camera.main.orthographicSize = camSizeNormal;
            Camera.main.transform.position = new Vector3(0, 0, -10);
        }
    }
}
