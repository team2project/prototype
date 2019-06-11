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

    private int Dateyear;                         　　//DateDropdownを決める際に使用する年
    private int Datemonth;                        　　//DateDropdownを決める際に使用する月
    private int Dateday;                          　　//DateDropdownを決める際に使用する日
    private int days;                             　　//現在の月の日数
    private DateTime now;                         　　//現在の日付が格納されている
    private CSVReader csvReader;                  　　//CSVファイルからデータを読み込むために使用
    private WeatherController weatherController;  　　//天気を変えるために使用
    private string DropdownDate;                  　　//現在選択されている日付
    private string cityName;                      　　//現在選択されている都市の名前
    private List<string> Date = new List<string>();   //CSVファイルのデータと比較するためのリスト
    private string[] cityNames = {"Hakodate","Tokyo", "Osaka", "Sapporo", "Yokohama"};  //都市名のデータ

    // Start is called before the first frame update
    void Start()
    {
        now = DateTime.Now;
        SetDateValue(Dateyear, Datemonth, Dateday, days, now);
        SetTimeDropdown();
        rainParticle.Stop();
        snowParticle.Stop();
        csvReader = new CSVReader();
        weatherController = new WeatherController();
        DropdownDate = GetDateElement(GetDate(), 0);  //現在選択されている日付として今日の日付を設定する
        cityName = cityNames[0];                      //現在選択されている都市名として函館を設定する

        csvReader.ShowBaseWeatherData(csvReader.GetHakodateWeather(), "函館市");
        csvReader.ShowBaseWeatherData(csvReader.GetTokyoWeather(), "東京都");
        csvReader.ShowBaseWeatherData(csvReader.GetOsakaWeather(), "大阪府");
        csvReader.ShowBaseWeatherData(csvReader.GetSapporoWeather(), "札幌市");
        csvReader.ShowBaseWeatherData(csvReader.GetYokohamaWeather(), "横浜市");
    }

    // Update is called once per frame
    /*void Update()
    {
       
    }*/

    //ゲッター
    public List<string> GetDate()
    {
        return this.Date;
    }

    //ゲッター
    public string GetDateElement(List<string> Date, int i)
    {
        return Date[i];
    }

    //ゲッター
    public string GetDropdownDate()
    {
        return this.DropdownDate;
    }

    //WeatherDropdownで選択されている天気をフィールド上で動作させる
    /*public void OnWeatherChanged()
    {
        //晴れの時
        if (WeatherDropdown.value == 0)
        {
            weatherController.RainWeather(rainParticle, snowParticle);
        }
        //雨の時
        else if (WeatherDropdown.value == 1)
        {
            weatherController.SnowWeather(rainParticle, snowParticle);
        }
        //雪の時
        else if (WeatherDropdown.value == 2)
        {
            weatherController.OtherWeather(rainParticle, snowParticle);
        }

    }*/

    //現在の年月日をそれぞれの変数に代入して初期化する
    public void SetDateValue(int year, int month, int day, int days, DateTime dateTime)
    {
        year = dateTime.Year;                     //現在の年
        month = dateTime.Month;                   //現在の月
        day = dateTime.Day;                       //現在の日
        days = dateTime.DaysInMonth();            //現在の月の日数
        SetDateDropdown(year, month, day, days);  //現在の年,月,日,日数から日付のドロップダウンに1週間分の日付を設定
    }

    //日付のドロップダウンに現在の日付から1週間分の日付を設定
    public void SetDateDropdown(int year, int month, int day, int days)
    {
        if (DateDropdown)
        {
            //DateDropdownの初期化
            DateDropdown.ClearOptions();
            List<string> DateList = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                DateList.Add(month.ToString() + "月" + day.ToString() + "日");
                GetDate().Add(year.ToString() + "/" + month.ToString() + "/" + day.ToString());
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
            }

            //DateDropdownにDateListの内容を反映
            DateDropdown.AddOptions(DateList);
            //DateDropdown.valueが0から始まるようにする
            DateDropdown.value = 0;
        }
    }

    //時間のドロップダウンに1:00～24:00を設定
    public void SetTimeDropdown()
    {
        if (TimeDropdown)
        {
            //TimeDropdownの初期化
            TimeDropdown.ClearOptions();
            List<string> TimeList = new List<string>();
            for (int time = 0; time < 24; time++)
            {
                TimeList.Add(time.ToString() + ":" + "00");
            }

            //TimeDropdownにTimeListの内容を反映
            TimeDropdown.AddOptions(TimeList);
            //TimeDropdown.valueが0から始まるようにする
            TimeDropdown.value = 0;
        }
    }

    //フィールドで函館、東京、大阪、札幌、横浜のどの都市が表示されるか決める
    public void ChangeCitySetActive(bool city1, bool city2, bool city3, bool city4, bool city5)
    {
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
            //函館を表示して,現在選択されている都市名を函館にする
            ChangeCitySetActive(true, false, false, false, false);
            cityName = cityNames[0];
        }
        //東京の時
        else if(CityDropdown.value == 1)
        {
            //東京を表示して,現在選択されている都市名を東京にする
            ChangeCitySetActive(false, true, false, false, false);
            cityName = cityNames[1];
        }
        //大阪の時
        else if (CityDropdown.value == 2)
        {
            //大阪を表示して,現在選択されている都市名を大阪にする
            ChangeCitySetActive(false, false, true, false, false);
            cityName = cityNames[2];
        }
        //札幌の時
        else if (CityDropdown.value == 3)
        {
            //札幌を表示して,現在選択されている都市名を札幌にする
            ChangeCitySetActive(false, false, false, true, false);
            cityName = cityNames[3];
        }
        //横浜の時
        else if (CityDropdown.value == 4)
        {
            //横浜を表示して,現在選択されている都市名を横浜にする
            ChangeCitySetActive(false, false, false, false, true);
            cityName = cityNames[4];
        }
    }

    //DateDropdownで選択されている日付を取得する
    public void OnDateChanged()
    {
        if (DateDropdown.value == 0)
        {
            //現在選択されている日付を今日の日付にする
            DropdownDate = GetDateElement(GetDate(), 0);
        }
        else if (DateDropdown.value == 1)
        {
            //現在選択されている日付を明日の日付にする
            DropdownDate = GetDateElement(GetDate(), 1);
        }
        else if (DateDropdown.value == 2)
        {
            //現在選択されている日付を2日後の日付にする
            DropdownDate = GetDateElement(GetDate(), 2);
        }
        else if (DateDropdown.value == 3)
        {
            //現在選択されている日付を3日後の日付にする
            DropdownDate = GetDateElement(GetDate(), 3);
        }
        else if (DateDropdown.value == 4)
        {
            //現在選択されている日付を4日後の日付にする
            DropdownDate = GetDateElement(GetDate(), 4);
        }
        else if (DateDropdown.value == 5)
        {
            //現在選択されている日付を5日後の日付にする
            DropdownDate = GetDateElement(GetDate(), 5);
        }
        else if (DateDropdown.value == 6)
        {
            //現在選択されている日付を6日後の日付にする
            DropdownDate = GetDateElement(GetDate(), 6);
        }
    }

    public void WeatherChange()
    {
        string DropdownDate = GetDropdownDate();

        if (cityName.Equals("Hakodate"))
        {
            SetWeatherStrength(csvReader.GetHakodateWeather(), DropdownDate, rainParticle, snowParticle);
        }
        else if (cityName.Equals("Tokyo"))
        {
            SetWeatherStrength(csvReader.GetTokyoWeather(), DropdownDate, rainParticle, snowParticle);
        }
        else if (cityName.Equals("Osaka"))
        {
            SetWeatherStrength(csvReader.GetTokyoWeather(), DropdownDate, rainParticle, snowParticle);
        }
        else if (cityName.Equals("Sapporo"))
        {
            SetWeatherStrength(csvReader.GetSapporoWeather(), DropdownDate, rainParticle, snowParticle);
        }
        else if (cityName.Equals("Yokohama"))
        {
            SetWeatherStrength(csvReader.GetYokohamaWeather(), DropdownDate, rainParticle, snowParticle);
        }
    }

    public void SetWeatherStrength(BaseWeather[] baseWeather, string DropdownDate, ParticleSystem rainParticle, ParticleSystem snowParticle)
    {
        for (int i = 0; i < baseWeather.Length; i++)
        {
            if (DropdownDate.Equals(baseWeather[i].GetDate())){
  
                if (baseWeather[i].GetWeather().Equals("雨"))
                {
                    weatherController.ChangeRainStrength(baseWeather[i].GetFallAmount(), rainParticle);

                    //天気が雨なら雪のパーティクルを止めて、雨のパーティクルを開始させて雨を降らせる
                    weatherController.RainWeather(rainParticle, snowParticle);
                }
                else if (baseWeather[i].GetWeather().Equals("雪"))
                {
                    weatherController.ChangeSnowStrength(baseWeather[i].GetFallAmount(), snowParticle);

                    //天気が雪なら雨のパーティクルを止めて、雪のパーティクルを開始させて雪を降らせる
                    weatherController.SnowWeather(rainParticle, snowParticle);
                }
                else
                {
                    //天気が雨でも雪でもないなら雨と雪のパーティクルを止める
                    weatherController.OtherWeather(rainParticle, snowParticle);
                }

                break;
            }
        }
    }
}
