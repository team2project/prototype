using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class WeatherController : MonoBehaviour
public class WeatherController
{
    //降水量から雨,雪の強さを決定する
    private float CalculateRateOverTime(float fallAmount)
    {
        //仮に設定(ここに降水量から雨の強さを決める式を定義する)
        return fallAmount * 90;
    }

    //CalculateRateOverTimeで計算した雨の強さをrainParticleに反映
    public void ChangeRainStrength(float rainStrength, ParticleSystem rainParticle)
    {
        //ParticleSystemのrateOverTimeを設定するために使用
        ParticleSystem.EmissionModule emission = rainParticle.emission;
        
        //emission.rateOverTimeで雨の強さを変える
        emission.rateOverTime = CalculateRateOverTime(rainStrength);
    }

    //CalculateRateOverTimeで計算した雪の強さをsnowParticleに反映
    public void ChangeSnowStrength(float snowStrength, ParticleSystem snowParticle)
    {
        //ParticleSystemのrateOverTimeを設定するために使用
        ParticleSystem.EmissionModule emission = snowParticle.emission;

        //emission.rateOverTimeで雪の強さを変える
        emission.rateOverTime = CalculateRateOverTime(snowStrength);
    }

    //天気を雨にする
    public void RainWeather(ParticleSystem rainParticle, ParticleSystem snowParticle)
    {
        rainParticle.Play();
        snowParticle.Stop();
        snowParticle.Clear();
    }

    //天気を雪にする
    public void SnowWeather(ParticleSystem rainParticle, ParticleSystem snowParticle)
    {
        snowParticle.Play();
        rainParticle.Stop();
        rainParticle.Clear();
    }

    //天気をその他(雨,雪以外)にする
    public void OtherWeather(ParticleSystem rainParticle, ParticleSystem snowParticle)
    {
        rainParticle.Stop();
        rainParticle.Clear();
        snowParticle.Stop();
        snowParticle.Clear();
    }

    //天気に応じてskyboxを変更する
    public void ChangeSkybox(Material skybox)
    {
        RenderSettings.skybox = skybox;
    }

    //雨の強さに応じて雨の音を変える
    public void ChangeRainSound(float rainStrength, AudioSource light_rain, AudioSource rain, AudioSource heavy_rain)
    {
        //rainStrengthが降水量(15mm)*90より低ければ
        if (rainStrength < 15 * 90)
        {
            light_rain.Play();
            rain.Stop();
            heavy_rain.Stop();
        }
        else if (15 * 90 <= rainStrength && rainStrength < 35 * 90)
        {
            light_rain.Stop();
            rain.Play();
            heavy_rain.Stop();
        }
        else
        {
            light_rain.Stop();
            rain.Stop();
            heavy_rain.Play();
        }
            
    }
}
