using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMPlayerTrigger : MonoBehaviour
{
    WorldmapManager worldmapM;
    private void Start()
    {
        worldmapM = WorldmapManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Town")        { worldmapM.TownAtRange = c.GetComponent<TownData>().townObj; }
        if (c.tag == "Waypoint")    { worldmapM.IsPlayerMoving = false; }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Town") worldmapM.TownAtRange = null;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        worldmapM.IsPlayerMoving = false;
    }
}
