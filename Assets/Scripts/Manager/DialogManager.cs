using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public EventObj eventObjCurrent;

    bool isDialoguing; public bool IsDialoguing
    {
        get { return isDialoguing; }
        set
        {
            isDialoguing = value;
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && isDialoguing) DialogNext();
    }

    public void DialogEnable()
    {

    }
    public void DialogDisable()
    {

    }

    public void DialogStart()
    {
        idCurrent = 0;
        DialogNext();
        StartCoroutine(DialogStartDelay());
    }

    public void DialogNext()
    {
        if (idCurrent >= eventObjCurrent.narrativeList.Count) { DialogEnd(); return; }

        if (sceneCurrent != null) Destroy(sceneCurrent);
        GameObject sceneGMB = eventObjCurrent.narrativeList[idCurrent].sceneNarrative;
        sceneCurrent = Instantiate(sceneGMB, GMBSceneManager.instance.SceneCurrent.transform);
        idCurrent++;
    }

    void DialogEnd()
    {
        if (eventObjCurrent.eventNext == null) { IsDialoguing = false; return; }
        else EventManager.instance.EventStart(eventObjCurrent.eventNext);
    }

    IEnumerator DialogStartDelay()
    {
        yield return new WaitForSeconds(0.01f);
        IsDialoguing = true;
    }
}
