using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    public List<string> stringList;
    [SerializeField]
    public List<StreamReader> strReaderList;
    // Start is called before the first frame update
    void Start()
    {
        ReadCSVFiles();
    }

    void ReadCSVFiles()
    {
        StreamReader strReader = new StreamReader("Assets/MainEvent-1.csv");
        string data_String = strReader.ReadLine();

        if (data_String == null) return;
        string[] data_values = data_String.Split("NextLine()");

        for(int i = 0; i < data_values.Length; i++)
        {
            string data = data_values[i].Replace("\"", "");
            stringList.Add(data);
        }
    }
}
