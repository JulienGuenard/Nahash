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

    public void CameraChange(string sceneName)
    {
        float camSize = camSizeNormal;
        Vector3 camPos = new Vector3(0, 0, -10);

        if (sceneName == "SceneWorldmap")
        {
            camSize = camSizeWorldmap;
            camPos = new Vector3(0, -2.73f, -10);
        }

        CameraZoom(camSize);
        CameraMove(camPos);
    }
    public void CameraZoom(float val)
    {
        Camera.main.orthographicSize = val;
    }
    public void CameraMove(Vector3 val)
    {
        Camera.main.transform.position = val;
    }
}
