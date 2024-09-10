using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMPlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Town") 
        {
            TownObj townObj = collision.GetComponent<TownData>().townObj;
            WorldmapManager.instance.ShowEnterTownBtn(true, townObj); 
        }
            
        if (collision.tag == "Waypoint") { WorldmapManager.instance.IsWMPlayerMoving = false; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Town") WorldmapManager.instance.ShowEnterTownBtn(false, null);
    }
}
