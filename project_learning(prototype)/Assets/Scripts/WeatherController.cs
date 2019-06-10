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

        //emission.rateOverTime = 200;
        //emission.rateOverTime = 500;
    }

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
