using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapManager : MonoBehaviour
{
    public WorldmapPlayer player;
    public GameObject playerWaypoint;
    public GameObject enterTownBtn;

    #region References
    public static WorldmapManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        ShowEnterTownBtn(false);
    }

    public void MovePlayer()
    {
        playerWaypoint.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerWaypoint.transform.position = new Vector3(playerWaypoint.transform.position.x, playerWaypoint.transform.position.y, 0);
        player.MoveToWaypoint(playerWaypoint);
    }
    public void ShowEnterTownBtn(bool state)
    {
        enterTownBtn.SetActive(state);
    }
}
