using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapManager : MonoBehaviour
{
    public List<EventObj> eventRNGList;
    public float rngEventDelay;
    public WorldmapPlayer player;
    public GameObject playerWaypoint;
    public GameObject enterTownBtn;

    bool isPlayerMoving; public bool IsPlayerMoving
    {
        get { return isPlayerMoving; }
        set
        {
            if (!value)
            {
                StopAllCoroutines();
                playerWaypoint.transform.position = new Vector3(999, 999, 999);
            }
            if (value && !isPlayerMoving) StartCoroutine(IsPlayerMoving_RandomEvent());

            isPlayerMoving = value;
            player.IsMoving = value;
        }
    }

    float rngEventDelayCurrent = 0;

    #region References
    public static WorldmapManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    { 
        Player_ExitTown();
    }

    public void WorldmapEnable()
    {

    }
    public void WorldmapDisable()
    {
        IsPlayerMoving = false;
    }

    public void WMClick_PlayerMove()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        playerWaypoint.transform.position = pos;
        IsPlayerMoving = true;
    }
    public void Player_EnterTown(GameObject town)
    {
        UIManager.instance.EnterTownBtn.SetActive(true);
        Debug.Log(town.name);
        TownObj townObj = town.GetComponent<TownData>().townObj;

        enterTownBtn.GetComponent<ButtonInput>().townNext = townObj;
    }
    public void Player_ExitTown()
    {
        UIManager.instance.EnterTownBtn.SetActive(false);
    }

    private IEnumerator IsPlayerMoving_RandomEvent()
    {
        yield return new WaitForSeconds(0.01f);
        rngEventDelayCurrent += 0.01f;
        if (rngEventDelayCurrent < rngEventDelay)   StartCoroutine(IsPlayerMoving_RandomEvent());
        else                                        RandomEvent_New();
    }
    private void        RandomEvent_New()
    {
        rngEventDelayCurrent = 0;
        EventManager.instance.Worldmap_RandomEvent(eventRNGList);
    }
}
