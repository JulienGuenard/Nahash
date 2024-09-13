using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public List<EventObj> eventObjList;
    public int langID;
    public int langNumber;

    #region References
    public static LanguageManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) { Translate(Language.French); }
        if (Input.GetKeyDown(KeyCode.I)) { Translate(Language.English); }
        if (Input.GetKeyDown(KeyCode.O)) { Translate(Language.Spanish); }
    }

    public void Translate(Language lang)
    {
        switch(lang) 
        {
            case Language.French: langID = 0; break;
            case Language.English: langID = 1; break;
            case Language.Spanish: langID = 2; break;
        }
        ReadCSV.instance.ReadCSVFiles();
    }

    public void TranslateBack()
    {
        List<string> dialogList = ReadCSV.instance.stringList;

        for(int i = 0; i < eventObjList.Count; i++) 
        {
            for (int x = 0; i < eventObjList[i].evtSceneList.Count; x++)
            {
                if (x >= dialogList.Count) break;
                eventObjList[i].evtSceneList[x].dialogList[0].txt = dialogList[x];
            }
        }
    }
}
