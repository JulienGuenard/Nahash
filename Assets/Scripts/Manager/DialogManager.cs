using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    bool canPlayerPressDialogNext; public bool CanPlayerPressDialogNext // AutoEnabler
    {
        get { return canPlayerPressDialogNext; }
        set 
        {
            if (value)  StartCoroutine(DialogStart_InputDelay());
            else        canPlayerPressDialogNext = value;
        }
    }

    GameObject sceneCurrent = null;
    int idCurrent = 0;

    #region References
    public static DialogManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Update()
    {
        if (!canPlayerPressDialogNext) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && canPlayerPressDialogNext) DialogNext();
    }

    public void DialogStart()
    {
        idCurrent = 0;
        DialogNext();
        CanPlayerPressDialogNext = true;
    }
    public void DialogNext()
    {
        EventObj eventCurrent = EventManager.instance.EventCurrent;
        int narrativeListCount = eventCurrent.narrativeList.Count;

        if (idCurrent >= narrativeListCount)    DialogNext_End(eventCurrent);
        else                                    DialogNext_New(eventCurrent);
    }

    private void DialogNext_New(EventObj eventCurrent)
    {
        if (sceneCurrent != null) Destroy(sceneCurrent);

        GameObject sceneGMB = eventCurrent.narrativeList[idCurrent].sceneNarrative;
        sceneCurrent = Instantiate(sceneGMB, GMBSceneManager.instance.SceneCurrent.transform);
        idCurrent++;
    }
    private void DialogNext_End(EventObj eventCurrent)
    {
        EventObj eventNext = eventCurrent.eventNext;

        if (eventNext == null)  GMBSceneManager.instance.SceneNameCurrent = eventCurrent.sceneNext;
        else                    EventManager.instance.EventCurrent = eventNext;
    }

    IEnumerator DialogStart_InputDelay()
    {
        yield return new WaitForSeconds(0.01f);
        canPlayerPressDialogNext = true;
    }
}
