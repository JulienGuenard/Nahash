using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapManager : MonoBehaviour
{
    public float rngEventDelay;
    public WorldmapPlayer player;
    public GameObject playerWaypoint;
    public GameObject enterTownBtn;

    bool isWMPlayerMoving; public bool IsWMPlayerMoving
    {
        get { return isWMPlayerMoving; }
        set
        {
            if (!value)
            {
                StopAllCoroutines();
                playerWaypoint.transform.position = new Vector3(999, 999, 999);
            }
            if (value && !isWMPlayerMoving) StartCoroutine(IsMoving_RandomEvent());

            isWMPlayerMoving = value;
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
        ShowEnterTownBtn(false);
    }

    public void WorldmapEnable()
    {

    }
    public void WorldmapDisable()
    {
        IsWMPlayerMoving = false;
    }

    public void MovePlayer()
    {
        playerWaypoint.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
        IsWMPlayerMoving = true;
    }
    public void ShowEnterTownBtn(bool state)
    {
        enterTownBtn.SetActive(state);
    }

    private IEnumerator IsMoving_RandomEvent()
    {
        yield return new WaitForSeconds(0.01f);
        rngEventDelayCurrent += 0.01f;
        if (rngEventDelayCurrent < rngEventDelay)
        {
            StartCoroutine(IsMoving_RandomEvent());
        }else
        {
            rngEventDelayCurrent = 0;
        }
    }
}
