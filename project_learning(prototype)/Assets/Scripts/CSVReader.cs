using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System.Text;

public class CSVReader : MonoBehaviour
{ 
    TextAsset csvFile;  //csvファイル
    private List<string[]> csvDatas = new List<string[]>();  //csvの中身を入れるリスト
    //Encoding encoding;

    //ゲッター
    public List<string[]> GetCsvDatas()
    {
        return this.csvDatas;
    }

    // Start is called before the first frame update
    //CSVファイルを読み込む
    void Start()
    {
        //this.encoding = Encoding.GetEncoding("utf-8");
        csvFile = Resources.Load("sampledata") as TextAsset;  //Resourcesの下のCSVファイルを読み込む
        StringReader reader = new StringReader(csvFile.text);

        //","で分割しつつ一行ずつ読み込み
        //csvFilesに追加していく
        while (reader.Peek() != -1)  //reader.Peekが-1になるまで(読み込めるものがなくなったときPeekは-1になる)
        {
            string line = reader.ReadLine(); //1行を読み込み
            csvDatas.Add(line.Split(','));   //","で区切ってリストに追加する
        }

        for (int i = 1; i < csvDatas.Count; i++)
        {
            Debug.Log(csvDatas[i][0] + ":" + csvDatas[i][1]);
        }
        //Debug.Log(csvDatas[1][0] + ":" + csvDatas[1][1]);
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

}
