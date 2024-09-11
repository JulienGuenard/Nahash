using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMPlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Town")        { WorldmapManager.instance.Player_EnterTown(collision.gameObject);  }
        if (collision.tag == "Waypoint")    { WorldmapManager.instance.IsPlayerMoving = false; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Town") WorldmapManager.instance.Player_ExitTown();
    }
}
