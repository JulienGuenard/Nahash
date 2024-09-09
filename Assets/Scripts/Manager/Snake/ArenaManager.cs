using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] private GameObject arenaGMB;
    public Vector2 gridX;
    public Vector2 gridY;
    public Transform gridTransform;

    #region References
    public static ArenaManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
