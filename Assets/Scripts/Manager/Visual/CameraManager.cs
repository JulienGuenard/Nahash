using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float camSizeNormal, camSizeWorldmap;

    #region References
    public static CameraManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void     CameraChange(string sceneName)
    {
        float camSize =     CameraChange_SetSize(sceneName);
        Vector3 camPos =    CameraChange_SetZoom(sceneName);
                       /*     CameraZoom(camSize);
                            CameraMove(camPos);*/
    }
    public void     CameraZoom(float val)
    {
        Camera.main.orthographicSize = val;
    }
    public void     CameraMove(Vector3 val)
    {
        Camera.main.transform.position = val;
    }

    private float   CameraChange_SetSize(string sceneName)
    {
        if (sceneName == "SceneWorldmap")   return camSizeWorldmap;
        else                                return camSizeNormal;
    }
    private Vector3 CameraChange_SetZoom(string sceneName)
    {
        if (sceneName == "SceneWorldmap")   return new Vector3(0, -2.73f, -10);
        else                                return new Vector3(0, 0, -10);
    }
}
