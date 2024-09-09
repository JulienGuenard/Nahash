using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject sceneEvent;

    #region References
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
