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
        set 
        {
            if (!isMoving && value) StartCoroutine(Move());
            isMoving = value;
        } 
    }

    GameObject waypoint;

    private void Start()
    {
        waypoint = WorldmapManager.instance.playerWaypoint;
    }

    private IEnumerator Move()
    {
        Vector2 moveTowards = Vector2.MoveTowards(player.transform.position, waypoint.transform.position, speed);
        player.GetComponentInChildren<CircleCollider2D>().offset = moveTowards - (Vector2)player.transform.position;
        yield return new WaitForSeconds(0.02f);
        player.GetComponentInChildren<CircleCollider2D>().offset = Vector2.zero;
        if (isMoving)
        {
            player.transform.position = moveTowards;
            StartCoroutine(Move());
        }
    }
}
