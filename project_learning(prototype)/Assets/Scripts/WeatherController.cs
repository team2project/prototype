using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class WeatherController : MonoBehaviour
public class WeatherController
{
    //private CSVReader csvReader;
    
    //public ParticleSystem rainParticle;    //雨のParticleSystemを管理
    //public ParticleSystem snowParticle;    //雪のParticleSystemを管理

    // Start is called before the first frame update
    /*void Start()
    {
        //csvReader= new CSVReader();
    }*/

    private float CalculateRateOverTime(float fallAmount)
    {
        //仮に設定(ここに降水量から雨の強さを決める式を定義する)
        return fallAmount * 90;
    }

    public void ChangeRainStrength(float rainStrength, ParticleSystem rainParticle)
    {
        ParticleSystem.EmissionModule emission = rainParticle.emission;
        
        //emission.rateOverTimeで雨の強さを変える
        emission.rateOverTime = CalculateRateOverTime(rainStrength);
    }

    public void ChangeSnowStrength(float snowStrength, ParticleSystem snowParticle)
    {
        ParticleSystem.EmissionModule emission = snowParticle.emission;

        //emission.rateOverTimeで雪の強さを変える
        emission.rateOverTime = CalculateRateOverTime(snowStrength);
    }

    public void RainWeather(ParticleSystem rainParticle, ParticleSystem snowParticle)
    {
        rainParticle.Play();
        snowParticle.Stop();
        snowParticle.Clear();
    }

    public void SnowWeather(ParticleSystem rainParticle, ParticleSystem snowParticle)
    {
        snowParticle.Play();
        rainParticle.Stop();
        rainParticle.Clear();
    }

    public void OtherWeather(ParticleSystem rainParticle, ParticleSystem snowParticle)
    {
        rainParticle.Stop();
        rainParticle.Clear();
        snowParticle.Stop();
        snowParticle.Clear();
    }

    /*public void changeWeather(ParticleSystem rainParticle, ParticleSystem snowParticle, string weather)
    {
        if (weather.Equals("雨"))
            RainWeather(rainParticle, snowParticle);
        else if (weather.Equals("雪"))
            SnowWeather(rainParticle, snowParticle);
        else
            OtherWeather(rainParticle, snowParticle);
    }*/


    // Update is called once per frame
    /*void Update()
    {
        //pressButton(rainParticle);
        dx = Input.GetAxis("Horizontal");
        dy = Input.GetAxis("Vertical");
        Camera.main.transform.rotation = Quaternion.Euler(dx, dy, 0);
        //Camera.main.transform.rotation(dx, dy, 0);
    }*/

    /*void pressButton(ParticleSystem weatherParticle)
    {
        //Pが押されたらパーティクルが作動する
        if (Input.GetKey(KeyCode.P))
        {
            weatherParticle.Play();
        }
        //Sが押されたらパーティクルが停止する
        if (Input.GetKey(KeyCode.S))
        {
            weatherParticle.Stop();
        }
        //Spaceが押されたら
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }*/

}
