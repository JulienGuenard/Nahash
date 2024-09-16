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
        CameraChange_SetZoom(sceneName);
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
    private void CameraChange_SetZoom(string sceneName)
    {
        if (sceneName == "SceneWorldmap")
        {
            Camera.main.transform.SetParent(WorldmapManager.instance.playerToken.transform);
            Camera.main.transform.position = WorldmapManager.instance.playerToken.transform.position + new Vector3(0, 0, -10);
        }else 
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.position = new Vector3(0, 0, -10);
        }
    }
}
