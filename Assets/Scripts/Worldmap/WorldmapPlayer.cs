using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapPlayer : MonoBehaviour
{
    public float speed;

    GameObject waypoint;
    bool isMoving;

    private void Update()
    {
        if (isMoving) Move();
    }

    public void MoveToWaypoint(GameObject playerWaypoint)
    {
        waypoint = playerWaypoint;
        isMoving = true;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Town") WorldmapManager.instance.ShowEnterTownBtn(true);
        if (collision.tag == "Waypoint")
        {
            isMoving = false;
            waypoint.transform.position = new Vector3(999, 999, 999);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Town") WorldmapManager.instance.ShowEnterTownBtn(false);
    }
}
