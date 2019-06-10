﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DropdownController : MonoBehaviour
{
    public Dropdown WeatherDropdown;       //天気のDropdownを管理
    public Dropdown CityDropdown;          //都市のDropdownを管理
    public Dropdown DateDropdown;          //日付のDropDownを管理
    public Dropdown TimeDropdown;          //時間のDropdownを管理
    public ParticleSystem rainParticle;    //雨のParticleSystemを管理
    public ParticleSystem snowParticle;    //雪のParticleSystemを管理
    public GameObject Hakodate;
    public GameObject Tokyo;
    public GameObject Osaka;
    public GameObject Sapporo;
    public GameObject Yokohama;

    //private int dataNum = 7;               //扱うデータの数
    private int Dateyear;                    //DateDropdownを決める際に使用する年
    private int Datemonth;                   //DateDropdownを決める際に使用する月
    private int Dateday;                     //DateDropdownを決める際に使用する日
    private int days;                        //現在の月の日数
    private DateTime now;
    private CSVReader csvReader;
    private WeatherController weatherController;
    private int year;
    private string todayDate;
    private string cityName;
    private List<string> Date = new List<string>();
    private string[] cityNames = {"Hakodate","Tokyo", "Osaka", "Sapporo", "Yokohama"};

    // Start is called before the first frame update
    void Start()
    {
        now = DateTime.Now;
        SetDateValue(Dateyear, Datemonth, Dateday, days, now);
        SetTimeDropdown();
        //SetDateValue(year, month, day, days, test);
        rainParticle.Stop();
        snowParticle.Stop();
        csvReader = new CSVReader();
        weatherController = new WeatherController();
        year = 2019;
        todayDate = GetDateElement(GetDates(), 0);
        cityName = cityNames[0];

        csvReader.ShowBaseWeatherData(csvReader.GetHakodateWeather(), "函館市");
        csvReader.ShowBaseWeatherData(csvReader.GetTokyoWeather(), "東京都");
        csvReader.ShowBaseWeatherData(csvReader.GetOsakaWeather(), "大阪府");
        csvReader.ShowBaseWeatherData(csvReader.GetSapporoWeather(), "札幌市");
        csvReader.ShowBaseWeatherData(csvReader.GetYokohamaWeather(), "横浜市");
    }

    // Update is called once per frame
    /*void Update()
    {
        if(cityName.Equals("Hakodate"))
        {
            for (int i = 0; i < csvReader.GetHakodateWeather().Length; i++)
            {
                if (todayDate.Equals(csvReader.GetHakodateWeather()[i].GetDate()))
                {
                    if (csvReader.GetHakodateWeather()[i].GetWeather().Equals("雨"))
                    {
                        weatherController.ChangeRainStrength(csvReader.GetHakodateWeather()[i].GetFallAmount(), rainParticle);
                    }
                    //else if (csvReader.GetHakodateWeather()[i].GetWeather().Equals("雪"))
                    //{

                    //}

                    break;
                }
            }
        }
        else if(cityName == "Tokyo")
        {

        }
        else if (cityName == "Osaka")
        {

        }
        else if (cityName == "Sapporo")
        {

        }
        else if (cityName == "yokohama")
        {

        }
    }*/

    public int GetYear()
    {
        return this.year;
    } 

    public List<string> GetDates()
    {
        return this.Date;
    }

    public string GetDateElement(List<string> Date, int i)
    {
        return Date[i];
    }

    //WeatherDropdownで選択されている天気をフィールド上で動作させる
    public void OnWeatherChanged()
    {
        //晴れの時
        if (WeatherDropdown.value == 0)
        {
            rainParticle.Stop();
            rainParticle.Clear();
            snowParticle.Stop();
            snowParticle.Clear();
        }
        //雨の時
        else if (WeatherDropdown.value == 1)
        {
            rainParticle.Play();
            snowParticle.Stop();
            snowParticle.Clear();
        }
        //雪の時
        else if (WeatherDropdown.value == 2)
        {
            rainParticle.Stop();
            rainParticle.Clear();
            snowParticle.Play();
        }

    }

    //現在の年月日をそれぞれの変数に代入して初期化する
    public void SetDateValue(int year, int month, int day, int days, DateTime dateTime)
    {
        year = dateTime.Year;
        month = dateTime.Month;
        day = dateTime.Day;
        days = dateTime.DaysInMonth();
        Debug.Log(year + "," + month + "," + day + "," + days);
        SetDateDropdown(month, day, days);
    }

    //日付のドロップダウンに現在の日付から1週間分の日付を設定
    public void SetDateDropdown(int month, int day, int days)
    {
        if (DateDropdown)
        {
            //ドロップダウンの初期化
            DateDropdown.ClearOptions();
            List<string> DateList = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                DateList.Add(month.ToString() + "月" + day.ToString() + "日");
                GetDates().Add(GetYear().ToString() + "/" + month.ToString() + "/" + day.ToString());
                //Debug.Log(days);
                //もし日付が月の最終日を超えたら日付を1日にして月に1を足して次の月にしている
                if (day + i >= days)
                {
                    day = 1;
                    month++;
                    if (month > 12)
                    {
                        month = 1;
                    }
                }
                else
                    day++;
                //DateList.Add(month.ToString() + "月" + day.ToString() + "日");
            }
            DateDropdown.AddOptions(DateList);
            DateDropdown.value = 0;
        }
    }

    //時間のドロップダウンに1:00～24:00を設定
    public void SetTimeDropdown()
    {
        if (TimeDropdown)
        {
            TimeDropdown.ClearOptions();
            List<string> TimeList = new List<string>();
            for (int time = 0; time < 24; time++)
            {
                TimeList.Add(time.ToString() + ":" + "00");
            }
            TimeDropdown.AddOptions(TimeList);
            TimeDropdown.value = 0;
        }
    }

    public void ChangeCitySetActive(bool city1, bool city2, bool city3, bool city4, bool city5)
    {
        //フィールドで函館、東京、大阪、札幌、横浜のどの都市が表示されるか決める
        //bool型の値がtureなら表示されて、falseなら表示されない
        Hakodate.SetActive(city1);
        Tokyo.SetActive(city2);
        Osaka.SetActive(city3);
        Sapporo.SetActive(city4);
        Yokohama.SetActive(city5);
    }

    //CityDropdownで選択されている都市を表示する
    public void OnCityChanged()
    {
        //函館の時
        if (CityDropdown.value == 0)
        {
            ChangeCitySetActive(true, false, false, false, false);
            cityName = cityNames[0];
        }
        //東京の時
        else if(CityDropdown.value == 1)
        {
            ChangeCitySetActive(false, true, false, false, false);
            cityName = cityNames[1];
        }
        //大阪の時
        else if (CityDropdown.value == 2)
        {
            ChangeCitySetActive(false, false, true, false, false);
            cityName = cityNames[2];
        }
        //札幌の時
        else if (CityDropdown.value == 3)
        {
            ChangeCitySetActive(false, false, false, true, false);
            cityName = cityNames[3];
        }
        //横浜の時
        else if (CityDropdown.value == 4)
        {
            ChangeCitySetActive(false, false, false, false, true);
            cityName = cityNames[4];
        }
    }

    public void OnDateChanged()
    {
        if (DateDropdown.value == 0)
        {
            todayDate = GetDateElement(GetDates(), 0);
        }
        else if (DateDropdown.value == 1)
        {
            todayDate = GetDateElement(GetDates(), 1);
        }
        else if (DateDropdown.value == 2)
        {
            todayDate = GetDateElement(GetDates(), 2);
        }
        else if (DateDropdown.value == 3)
        {
            todayDate = GetDateElement(GetDates(), 3);
        }
        else if (DateDropdown.value == 4)
        {
            todayDate = GetDateElement(GetDates(), 4);
        }
        else if (DateDropdown.value == 5)
        {
            todayDate = GetDateElement(GetDates(), 5);
        }
        else if (DateDropdown.value == 6)
        {
            todayDate = GetDateElement(GetDates(), 6);
        }
    }
}
