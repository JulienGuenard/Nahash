using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapInput : MonoBehaviour
{
    private void OnMouseDown()
    {
        WorldmapManager.instance.MovePlayer();
    }
}
