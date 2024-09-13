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

        for (int i = langID+langNumber+2; i < data.Count; i += langNumber+1)
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
