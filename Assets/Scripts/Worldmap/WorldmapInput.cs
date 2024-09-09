using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapInput : MonoBehaviour
{
    public void OnMouseDown()
    {
        WorldmapManager.instance.MovePlayer();
    }
}
