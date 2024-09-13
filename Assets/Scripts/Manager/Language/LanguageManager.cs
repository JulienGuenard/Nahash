using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public List<EventObj> eventObjList;
    public List<ButtonObj> buttonObjList;
    public int langNumber;

    private int langID; public int LangID
    { 
        get { return langID; } 
        set 
        { 
            langID = value;
            CSVManager.instance.Translate();
        }
    }

    #region References
    public static LanguageManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) { LangID = 0; }
        if (Input.GetKeyDown(KeyCode.I)) { LangID = 1; }
        if (Input.GetKeyDown(KeyCode.O)) { LangID = 2; }
    }

    public void TranslateEvent(List<string> dialogList)
    {
        int y = 0;
        for (int i = 0; i < eventObjList.Count; i++) 
        {
            for (int x = 0; x < eventObjList[i].evtSceneList.Count; x++)
            {
                if (y >= dialogList.Count) break;
                if (eventObjList[i].evtSceneList[x].evtSceneName != "Dialog") continue;

                eventObjList[i].evtSceneList[x].dialogList[0].txt = dialogList[y];
                y++;
            }
        }
    }

    public void TranslateButton(List<string> btnList)
    {
        for (int i = 0; i < buttonObjList.Count; i++)
        {
            buttonObjList[i].btnName = btnList[i];
        }

        foreach (ButtonInput btn in FindObjectsOfType<ButtonInput>())
        {
            btn.Rename();
        }
    }
}
