using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    TownObj townCurrent; public TownObj TownCurrent
    {
        get { return townCurrent; }
        set
        {
            townCurrent = value;
            if (townCurrent != null) TownCurrent_New();
        }
    }
    GameObject sceneCurrent = null;

    #region References
    public static TownManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void TownEnable()
    {
        TownCurrent = WorldmapManager.instance.TownAtRange;
    }
    public void TownDisable()
    {
        TownCurrent = null;
    }

    private void TownCurrent_New()
    {
        if (sceneCurrent != null) Destroy(sceneCurrent);

        sceneCurrent = Instantiate(townCurrent.townGMB, GMBSceneManager.instance.SceneCurrent.transform);
    }
}