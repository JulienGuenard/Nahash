using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    public List<string> stringList;

    #region References
    public static ReadCSV instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    void Start()
    {
        ReadCSVFiles();
    }

    public void ReadCSVFiles()
    {
        StreamReader strReader = new StreamReader("Assets/Scripts/ScriptableObj/CSV/Events/MainEvent-1.csv");
        string data_String = strReader.ReadToEnd();

        if (data_String == null) return;

        List<string> data_values = new List<string>();
        data_values.AddRange(data_String.Split("\n"));

        stringList.Clear();
        ReadFR(data_values);
    }

    void ReadFR(List<string> data_values)
    {
        data_values = Read1(data_values);
        data_values = Read2(data_values);
        Read3(data_values);
        LanguageManager.instance.TranslateBack();
    }

    List<string> Read1(List<string> data_values)
    {
        List<string> data_values2 = new List<string>();

        for (int i = 0; i < data_values.Count; i++)
        {
            data_values2.AddRange(data_values[i].Split(";"));
        }
        return data_values2;
    }

    List<string> Read2(List<string> data_values)
    {
        List<string> data_values2 = new List<string>();
        int langID = LanguageManager.instance.langID;
        int langNumber = LanguageManager.instance.langNumber;

        for (int i = langID+langNumber+2; i < data_values.Count; i += langNumber+1)
        {
            data_values2.Add(data_values[i]);
        }
        return data_values2;
    }

    void Read3(List<string> data_values)
    {
        for (int i = 0; i < data_values.Count; i++)
        {
            string data = data_values[i].Replace("\"", "");
            stringList.Add(data);
        }
    }
}
