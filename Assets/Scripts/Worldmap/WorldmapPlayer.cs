using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed;

    bool isMoving; public bool IsMoving
    { 
        get { return isMoving; } 
        set {  isMoving = value; } 
    }

    GameObject waypoint;

    private void Start()
    {
        waypoint = WorldmapManager.instance.playerWaypoint;
    }
    private void Update()
    {
        if (isMoving) Move();
    }
    private void Move()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, waypoint.transform.position, speed);
    }
}
