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
}
