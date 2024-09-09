using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    bool canPlayerPressDialogNext; public bool CanPlayerPressDialogNext
    {
        get { return canPlayerPressDialogNext; }
        set
        {
            canPlayerPressDialogNext = value;
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && canPlayerPressDialogNext) DialogNext();
    }

    public void DialogStart()
    {
        idCurrent = 0;
        DialogNext();
        StartCoroutine(DialogStart_InputDelay());
    }
    public void DialogNext()
    {
        EventObj eventCurrent = EventManager.instance.EventCurrent;

        if (idCurrent >= eventCurrent.narrativeList.Count) { DialogEnd(eventCurrent); return; }

        if (sceneCurrent != null) Destroy(sceneCurrent);

        CanPlayerPressDialogNext = true;

        GameObject sceneGMB = eventCurrent.narrativeList[idCurrent].sceneNarrative;
        sceneCurrent = Instantiate(sceneGMB, GMBSceneManager.instance.SceneCurrent.transform);
        idCurrent++;
    }

    private void DialogEnd(EventObj eventCurrent)
    {
        if (eventCurrent.eventNext == null) { GMBSceneManager.instance.SceneNameCurrent = eventCurrent.sceneNext; }
        else EventManager.instance.EventCurrent = eventCurrent.eventNext;
    }

    IEnumerator DialogStart_InputDelay()
    {
        yield return new WaitForSeconds(0.01f);
        CanPlayerPressDialogNext = true;
    }
}
