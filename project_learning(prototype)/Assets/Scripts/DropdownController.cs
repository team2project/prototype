using System.Collections;
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

    private int year;                      //現在の年
    private int month;                     //現在の月
    private int day;                       //現在の日
    private int days;                      //現在の月の日数
    private DateTime now;

    //BaseWeather baseWeather;
    //private DateTime test = new DateTime(2019,7,30);

    // Start is called before the first frame update
    void Start()
    {
        now = DateTime.Now;
        SetDateValue(year, month, day, days, now);
        SetTimeDropdown();
        //SetDateValue(year, month, day, days, test);
        rainParticle.Stop();
        snowParticle.Stop();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

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
    private void SetDateValue(int year, int month, int day, int days, DateTime dateTime)
    {
        year = dateTime.Year;
        month = dateTime.Month;
        day = dateTime.Day;
        days = dateTime.DaysInMonth();
        Debug.Log(year + "," + month + "," + day + "," + days);
        SetDateDropdown(month, day, days);
    }

    //日付のドロップダウンに現在の日付から1週間分の日付を設定
    private void SetDateDropdown(int month, int day, int days)
    {
        if (DateDropdown)
        {
            //ドロップダウンの初期化
            DateDropdown.ClearOptions();
            List<string> DateList = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                DateList.Add(month.ToString() + "月" + day.ToString() + "日");
                Debug.Log(days);
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
    private void SetTimeDropdown()
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
        }
        //東京の時
        else if(CityDropdown.value == 1)
        {
            ChangeCitySetActive(false, true, false, false, false);
        }
        //大阪の時
        else if (CityDropdown.value == 2)
        {
            ChangeCitySetActive(false, false, true, false, false);
        }
        //札幌の時
        else if (CityDropdown.value == 3)
        {
            ChangeCitySetActive(false, false, false, true, false);
        }
        //横浜の時
        else if (CityDropdown.value == 4)
        {
            ChangeCitySetActive(false, false, false, false, true);
        }
    }

}
