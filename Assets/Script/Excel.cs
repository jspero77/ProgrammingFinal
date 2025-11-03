using System.Collections;
    using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.TextCore.Text;

public class Excel : MonoBehaviour
{
    public UnityEngine.TextAsset emailList;

    [System.Serializable]
    public class Data
    {
        public string words;
        public int type;
        public int size;
        public int pairNumber;
        public int orderStart;
    }
    [System.Serializable]
    public class DataList
    {
        public Data[] emailData;
    }

    public DataList myDataList = new DataList();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReadCSV();
    }

    // Update is called once per frame
    void ReadCSV()
    {
        string[] data = emailList.text.Split(new String[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = data.Length / 5 - 1;
        myDataList.emailData = new Data[tableSize];
        for (int i = 0; i < tableSize; i++)
        {

            myDataList.emailData[i] = new Data();
            myDataList.emailData[i].words = data[5 * (i + 1)];
            myDataList.emailData[i].type = int.Parse(data[5 * (i + 1) + 1]);
            myDataList.emailData[i].size = int.Parse(data[5 * (i + 1) + 2]);
            myDataList.emailData[i].pairNumber = int.Parse(data[5 * (i + 1) + 3]);
            myDataList.emailData[i].orderStart = int.Parse(data[5 * (i + 1) + 4]);
        }

    }
}
