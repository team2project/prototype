using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class BaseWeather : MonoBehaviour
public class BaseWeather
{
    private string date;                     //日付を管理する
    private string weather;                  //天気を管理する
    private float fallAmount;                //降水量を管理する
    private float windStrength;              //風速を管理する

    //コンストラクタ
    public BaseWeather(string date, string weather)
    {
        this.date = date;
        this.weather = weather;
    }

    //コンストラクタ
    public BaseWeather(string date, string weather, float fallAmount, float windStrength)
    {
        this.date = date;
        this.weather = weather;
        this.fallAmount = fallAmount;
        this.windStrength = windStrength;
    }

    //ゲッター
    public string GetDate()
    {
        return this.date;
    }

    //ゲッター
    public string GetWeather()
    {
        return this.weather;
    }

    //ゲッター
    public float GetFallAmount()
    {
        return this.fallAmount;
    }

    //ゲッター
    public float GetWindStrength()
    {
        return windStrength;
    }

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
