using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvtSceneManager : MonoBehaviour
{
    bool canPlayerGoNext; public bool CanPlayerGoNext // AutoEnabler
    {
        get { return canPlayerGoNext; }
        set
        {
            StartCoroutine(CanPlayerGoNext_Delay(value));
        }
    }

    EventObj eventCurrent; public EventObj EventCurrent
    {
        get { return eventCurrent; }
        set
        {
            eventCurrent = value;
            idCurrent = -1;
            StartEvtScene();
        }
    }

    private GameObject sceneCurrent = null;
    private int idCurrent = 0;

    #region References
    public static EvtSceneManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void EvtSceneEnable()
    {
        CanPlayerGoNext = true;
    }
    public void EvtSceneDisable()
    {
        CanPlayerGoNext = false;
    }

    public void StartEvtScene()
    {
        EvtSceneEnable();
        Next();
    }

    public void Next()
    {
        idCurrent++;

        if (idCurrent < eventCurrent.evtSceneList.Count)
        {
            List<FadeStruct> fadeStructList = eventCurrent.evtSceneList[idCurrent].fadeList;
            if (fadeStructList.Count > 0) { FadeManager.instance.NextBtn_FadeEvent(fadeStructList[0].time); return; }
            else                            Next_New();
        }
        else { Next_End(); return; }

        List<ItemObj> itemObjList = eventCurrent.evtSceneList[idCurrent].itemList;
        if (itemObjList.Count > 0) { Next_IsNewItem(itemObjList); }

        List<DialogStruct> dialogStructList = eventCurrent.evtSceneList[idCurrent].dialogList;
        if (dialogStructList.Count > 0) { Next_IsDialog(dialogStructList); return; }

        List<SnakeStruct> snakeStructList = eventCurrent.evtSceneList[idCurrent].snakeList;
        if (snakeStructList.Count > 0) { Next_IsSnake(snakeStructList); return; }


    }
    private void Next_New()
    {
        if (sceneCurrent != null) Destroy(sceneCurrent);

        GameObject sceneGMB = eventCurrent.evtSceneList[idCurrent].gmb;
        sceneCurrent = Instantiate(sceneGMB, GMBSceneManager.instance.SceneCurrent.transform);
    }
    private void Next_End()
    {
        EventObj eventNext = eventCurrent.eventNext;

        if (eventNext == null) GMBSceneManager.instance.SceneNameCurrent = eventCurrent.sceneNext;
        else EventCurrent = eventNext;
    }

    private void Next_IsDialog(List<DialogStruct> dialogStructList)
    {
        CanPlayerGoNext = false;

        UIManager.instance.DialogTxt = sceneCurrent.GetComponentInChildren<TextMeshPro>();
        VoiceManager.instance.VoicePlay(dialogStructList[0]);
    }
    private void Next_IsSnake(List<SnakeStruct> snakeStructList)
    {
        CanPlayerGoNext = false;
        
        UIManager.instance.ScoreTxt = GameObject.Find("SnakeView/Score").GetComponent<TextMeshPro>();
        UIManager.instance.TimeTxt = GameObject.Find("SnakeView/Time").GetComponent<TextMeshPro>();
        UIManager.instance.LifeTxt = GameObject.Find("SnakeView/Life").GetComponent<TextMeshPro>();
        ArenaManager.instance.GridTransform = GameObject.Find("SnakeView/GrpWall").transform;
        SnakeManager.instance.PlayerSnake = GameObject.Find("Snake/SnakeHead").GetComponent<Snake>();

        if (snakeStructList[0].scoreGoal == 0)
            UIManager.instance.ScoreTxt.gameObject.SetActive(false);
        else
        {
            ScoreManager.instance.ScoreGoal = snakeStructList[0].scoreGoal;
            ScoreManager.instance.ScoreReset();
        }

        if (snakeStructList[0].timeToWait == 0 || snakeStructList[0].timeToWait > 950)
        UIManager.instance.TimeTxt.gameObject.SetActive(false);
        else TimerManager.instance.TimerTimeLeft = snakeStructList[0].timeToWait;

    }
    private void Next_IsNewItem(List<ItemObj> itemStructList)
    {
        foreach(ItemObj itemObj in itemStructList) 
        {
            ItemManager.instance.ItemListAdd(itemObj);
        }
    }

    IEnumerator CanPlayerGoNext_Delay(bool value)
    {
        yield return new WaitForSeconds(0.01f);
        canPlayerGoNext = value;
    }
}
