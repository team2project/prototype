using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeather : MonoBehaviour
{
    private string weather;                  //天気を管理する
    private int fallAmount;                 //降水量を管理する

    //コンストラクタ
    public BaseWeather(string weather, int fallAmount)
    {
        this.weather = weather;
        this.fallAmount = fallAmount;
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
