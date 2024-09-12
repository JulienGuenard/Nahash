using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    public List<string> stringList;
    public List<string> stringListFR;
    public List<string> stringListENG;

    void Start()
    {
        ReadCSVFiles();
    }

    void ReadCSVFiles()
    {
        StreamReader strReader = new StreamReader("Assets/MainEvent-1.csv");
        string data_String = strReader.ReadToEnd();

        if (data_String == null) return;

        Read(data_String);
        ReadFR(data_String);
        ReadENG(data_String);
    }

    void Read(string data_String)
    {
        List<string> data_values = new List<string>();
        data_values.AddRange(data_String.Split("\n"));

        for (int i = 0; i < data_values.Count - 1; i++)
        {
            string data = data_values[i].Replace("\"", "");
            stringList.Add(data);
        }
    }

    void ReadFR(string data_String)
    {
        List<string> data_values = new List<string>();
        data_values.AddRange(data_String.Split("\n"));

        List<string> data_values2 = new List<string>();
        for (int i = 0; i < data_values.Count; i++)
        {
            data_values2.AddRange(data_values[i].Split(";"));
            data_values2.RemoveAt(data_values2.Count-1);
        }

        for (int i = 0; i < data_values2.Count; i++)
        {
            string data = data_values2[i].Replace("\"", "");
            stringListFR.Add(data);
        }
    }

    void ReadENG(string data_String)
    {
        List<string> data_values = new List<string>();
        data_values.AddRange(data_String.Split("\n"));

        List<string> data_values2 = new List<string>();
        for (int i = 0; i < data_values.Count; i++)
        {
            data_values2.AddRange(data_values[i].Split(";"));
            data_values2.RemoveAt(i);
        }


        for (int i = 0; i < data_values2.Count; i++)
        {
            string data = data_values2[i].Replace("\"", "");
            stringListENG.Add(data);
        }
    }
}
