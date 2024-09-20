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
    public List<TooltipObj> tooltipObjList;
    public List<QuestObj> questObjList;
    public List<ItemObj> itemObjList;
    public List<TownObj> townObjList;
    public List<CharacterObj> characterObjList;
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

    private void Start()
    {
        LangID = 0;
    }

    public void TranslateEvent(List<string> strList)
    {
        int y = 0;
        for (int i = 0; i < eventObjList.Count; i++) 
        {
            for (int x = 0; x < eventObjList[i].evtSceneList.Count; x++)
            {
                if (y >= strList.Count) break;
                if (eventObjList[i].evtSceneList[x].evtSceneName != "Dialog") continue;

                eventObjList[i].evtSceneList[x].dialogList[0].txt = strList[y];
                y++;
            }
        }
    }
    public void TranslateButton(List<string> strList)
    {
        for (int i = 0; i < buttonObjList.Count; i++)
        {
            buttonObjList[i].btnName = strList[i];
        }

        foreach (ButtonInput btn in FindObjectsOfType<ButtonInput>())
        {
            btn.Rename();
        }
    }
    public void TranslateTooltipTitle(List<string> strList)
    {
        for (int i = 0; i < tooltipObjList.Count; i++)
        {
            tooltipObjList[i].title = strList[i];
        }
    }
    public void TranslateTooltipText(List<string> strList)
    {
        for (int i = 0; i < tooltipObjList.Count; i++)
        {
            tooltipObjList[i].text = strList[i];
        }
    }
    public void TranslateCharacter(List<string> strList)
    {
        for (int i = 0; i < tooltipObjList.Count; i++)
        {
            characterObjList[i].characterName = strList[i];
        }
    }
    public void TranslateTown(List<string> strList)
    {

    }
    public void TranslateItem(List<string> strList)
    {
        for (int i = 0; i < tooltipObjList.Count; i++)
        {
            itemObjList[i].itemName = strList[i];
        }
    }
    public void TranslateQuestTitle(List<string> strList)
    {
        for (int i = 0; i < tooltipObjList.Count; i++)
        {
            questObjList[i].questName = strList[i];
        }
    }
    public void TranslateQuestText(List<string> strList)
    {
        for (int i = 0; i < tooltipObjList.Count; i++)
        {
            questObjList[i].description = strList[i];
        }
    }
}
