﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System.Text;

//public class CSVReader : MonoBehaviour
public class CSVReader
{
    //TextAsset csvFile;  //csvファイル
    private int dataNum = 7;  //csvファイルのデータの数
    private List<string[]> Hakodate = new List<string[]>();  //函館の天気を入れるリスト
    private List<string[]> Tokyo = new List<string[]>();     //東京の天気を入れるリスト
    private List<string[]> Osaka = new List<string[]>();     //大阪の天気を入れるリスト
    private List<string[]> Sapporo = new List<string[]>();   //札幌の天気を入れるリスト
    private List<string[]> Yokohama = new List<string[]>();  //横浜の天気を入れるリスト

    private BaseWeather[] HakodateWeather;  //函館の天気の情報を管理  
    private BaseWeather[] TokyoWeather;     //東京の天気の情報を管理
    private BaseWeather[] OsakaWeather;     //大阪の天気の情報を管理
    private BaseWeather[] SapporoWeather;   //札幌の天気の情報を管理
    private BaseWeather[] YokohamaWeather;  //横浜の天気の情報を管理


    //Encoding encoding;

    //ゲッター
    public BaseWeather[] GetBaseWeather(BaseWeather[] baseWeather)
    {
        return baseWeather;
    }

    /*public void setBaseWeather(BaseWeather[] baseWeather)
    {
        
    }*/

    /*public void SetBaseWeather(BaseWeather[] weather, int dataNum)
    {
        weather = new BaseWeather[dataNum];
    }*/

    //コンストラクタ
    public CSVReader()
    {
        HakodateWeather = new BaseWeather[dataNum];
        TokyoWeather = new BaseWeather[dataNum];
        OsakaWeather = new BaseWeather[dataNum];
        SapporoWeather = new BaseWeather[dataNum];
        YokohamaWeather = new BaseWeather[dataNum];

        Hakodate = CSVRead("HakodateWeatherData");
        Tokyo = CSVRead("TokyoWeatherData");
        Osaka = CSVRead("OsakaWeatherData");
        Sapporo = CSVRead("SapporoWeatherData");
        Yokohama = CSVRead("YokohamaWeatherData");

        HakodateWeather = SetBaseWeather(Hakodate);
        TokyoWeather = SetBaseWeather(Tokyo);
        OsakaWeather = SetBaseWeather(Osaka);
        SapporoWeather = SetBaseWeather(Sapporo);
        YokohamaWeather = SetBaseWeather(Yokohama);
    }

    public BaseWeather[] GetHakodateWeather()
    {
        return this.HakodateWeather;
    }

    public BaseWeather[] GetTokyoWeather()
    {
        return this.TokyoWeather;
    }

    public BaseWeather[] GetOsakaWeather()
    {
        return this.OsakaWeather;
    }

    public BaseWeather[] GetSapporoWeather()
    {
        return this.SapporoWeather;
    }

    public BaseWeather[] GetYokohamaWeather()
    {
        return this.YokohamaWeather;
    }

    //BaseWeather [] baseWeather;
    //BaseWeather weatehr;

    // Start is called before the first frame update
    /*void Start()
    {
        //this.encoding = Encoding.GetEncoding("utf-8");

        HakodateWeather = new BaseWeather[dataNum];
        TokyoWeather = new BaseWeather[dataNum];
        OsakaWeather = new BaseWeather[dataNum];
        SapporoWeather = new BaseWeather[dataNum];
        YokohamaWeather = new BaseWeather[dataNum];

        Hakodate = CSVRead("HakodateWeatherData");
        Tokyo = CSVRead("TokyoWeatherData");
        Osaka = CSVRead("OsakaWeatherData");
        Sapporo = CSVRead("SapporoWeatherData");
        Yokohama = CSVRead("YokohamaWeatherData");

        HakodateWeather = SetBaseWeather(Hakodate);
        TokyoWeather = SetBaseWeather(Tokyo);
        OsakaWeather = SetBaseWeather(Osaka);
        SapporoWeather = SetBaseWeather(Sapporo);
        YokohamaWeather = SetBaseWeather(Yokohama);

        ShowBaseWeatherData(HakodateWeather, "函館市");
        ShowBaseWeatherData(TokyoWeather, "東京都");
        ShowBaseWeatherData(OsakaWeather, "大阪府");
        ShowBaseWeatherData(SapporoWeather, "札幌市");
        ShowBaseWeatherData(YokohamaWeather, "横浜市");
    }*/

    /*public void SetCSVData()
    {

    }*/

    //CSVファイルを読み込む
    public List<string[]> CSVRead(string fileName)
    {
        TextAsset csvFile;  //csvファイル
        csvFile = Resources.Load(fileName) as TextAsset;  //Resourcesの下のCSVファイルを読み込む
        StringReader reader = new StringReader(csvFile.text);

        List<string[]> csvDatas = new List<string[]>();  //csvの中身を入れるリスト

        //","で分割しつつ一行ずつ読み込み
        //csvFilesに追加していく
        while (reader.Peek() != -1)  //reader.Peekが-1になるまで(読み込めるものがなくなったときPeekは-1になる)
        {
            string line = reader.ReadLine(); //1行を読み込み
            csvDatas.Add(line.Split(','));   //","で区切ってリストに追加する
        }

        return csvDatas;
    }

    //CSVファイルで読み込んだデータをコンソールに表示する
    public void ShowCSVFile(List<string[]> csvDatas, string cityName)
    {
        Debug.Log(cityName + "のデータ");

        for (int i = 1; i < csvDatas.Count; i++)
        {
            Debug.Log(csvDatas[i][0] + ":" + csvDatas[i][1]);
        }
    }

    public BaseWeather[] SetBaseWeather(List<string[]> csvDatas)
    {
        BaseWeather [] baseWeather = new BaseWeather[7];
        for (int i = 0; i < baseWeather.Length; i++)
        {
            baseWeather[i] = new BaseWeather(csvDatas[i + 1][0], csvDatas[i + 1][1], float.Parse(csvDatas[i + 1][2]), float.Parse(csvDatas[i + 1][3]));
        }

        return baseWeather;
    }

    public void ShowBaseWeatherData(BaseWeather[] baseWeather, string cityName)
    {
        Debug.Log(cityName + "のデータ");

        for (int i = 0; i < baseWeather.Length; i++)
        {
            Debug.Log("日付:" + baseWeather[i].GetDate() + ", 天気:" + baseWeather[i].GetWeather() + ", 降水量:" + baseWeather[i].GetFallAmount() + ", 風速:" + baseWeather[i].GetWindStrength());
        }
    }
    
    // Update is called once per frame
    /*void Update()
    {
        
    }*/

}
