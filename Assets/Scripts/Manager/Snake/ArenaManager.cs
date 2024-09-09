using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public Vector2 gridX;
    public Vector2 gridY;
    Transform gridTransform; [HideInInspector] public Transform GridTransform
    { 
        get { return gridTransform; } 
        set { gridTransform = value; }
    } // AutoEnabler

    #region References
    public static ArenaManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
