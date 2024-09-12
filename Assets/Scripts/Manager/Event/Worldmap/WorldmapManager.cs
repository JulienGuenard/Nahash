using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldmapManager : MonoBehaviour
{
    TownObj townAtRange; public TownObj TownAtRange
    {
        get { return townAtRange; }
        set
        {
            townAtRange = value;
            if (townAtRange != null)    UIManager.instance.EnterTownBtn.SetActive(true);
            else                        UIManager.instance.EnterTownBtn.SetActive(false);
        }
    }

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
        TownAtRange = null;
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
