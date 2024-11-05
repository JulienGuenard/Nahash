using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVManager : MonoBehaviour
{
    #region References
    public static CSVManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void Translate()
    {
        TranslateEvent(new StreamReader("Assets/Scripts/ScriptableObj/CSV/Events/MainEvent-1.csv"));
        TranslateButton(new StreamReader("Assets/Scripts/ScriptableObj/CSV/UI/UI.csv"));
        TranslateTooltipTitle(new StreamReader("Assets/Scripts/ScriptableObj/CSV/Tooltips/TooltipsTitle.csv"));
        TranslateTooltipText(new StreamReader("Assets/Scripts/ScriptableObj/CSV/Tooltips/TooltipsText.csv"));
        TranslateCharacter(new StreamReader("Assets/Scripts/ScriptableObj/CSV/Characters/Characters.csv"));
        TranslateItem(new StreamReader("Assets/Scripts/ScriptableObj/CSV/Items/Items.csv"));
        //   TranslateTown(new StreamReader("Assets/Scripts/ScriptableObj/CSV/Towns/Towns.csv"));
        TranslateQuestTitle(new StreamReader("Assets/Scripts/ScriptableObj/CSV/Quests/QuestsTitle.csv"));
        TranslateQuestText(new StreamReader("Assets/Scripts/ScriptableObj/CSV/Quests/QuestsText.csv"));
    }

    private void TranslateEvent(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateEvent(data);
    }
    private void TranslateButton(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateButton(data);
    }
    private void TranslateTooltipTitle(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateTooltipTitle(data);
    }
    private void TranslateTooltipText(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateTooltipText(data);
    }
    private void TranslateCharacter(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateCharacter(data);
    }
    private void TranslateItem(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateItem(data);
    }
    private void TranslateTown(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateTown(data);
    }
    private void TranslateQuestTitle(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateQuestTitle(data);
    }
    private void TranslateQuestText(StreamReader csv)
    {
        List<string> data = SplitData(StreamToString(csv));
        LanguageManager.instance.TranslateQuestText(data);
    }

    private string StreamToString(StreamReader csv)
    {
        return csv.ReadToEnd();
    }

    private List<string> SplitData(string csvString)
    {
        List<string> data = new List<string>();
        data = SplitLines(csvString);
        data = SplitSquares(data);
        data = SplitLanguage(data);
        data = RemoveQuotes(data);
        return data;
    }
    private List<string> SplitLines(string csvString)
    {
        List<string> dataResult = new List<string>();
        dataResult.AddRange(csvString.Split("\n"));
        return dataResult;
    }
    private List<string> SplitSquares(List<string> data)
    {
        List<string> dataResult = new List<string>();

        for (int i = 0; i < data.Count; i++)
        {
            dataResult.AddRange(data[i].Split(";"));
        }
        return dataResult;
    }
    private List<string> SplitLanguage(List<string> data)
    {
        List<string> dataResult = new List<string>();
        int langID = LanguageManager.instance.LangID;
        int langNumber = LanguageManager.instance.langNumber;

        for (int i = langID+langNumber+4; i < data.Count; i += langNumber+2)
        {
            dataResult.Add(data[i]);
        }
        return dataResult;
    }
    private List<string> RemoveQuotes(List<string> data)
    {
        List<string> dataResult = new List<string>();
        for (int i = 0; i < data.Count; i++)
        {
            string str = data[i].Replace("\"", "");
            dataResult.Add(str);
        }
        return dataResult;
    }
}
