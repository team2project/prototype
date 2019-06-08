using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public ParticleSystem rainParticle;    //雨のParticleSystemを管理
    public ParticleSystem snowParticle;    //雪のParticleSystemを管理

    // Start is called before the first frame update
    void Start()
    {
        rainParticle.Stop();
        snowParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //pressButton(rainParticle);
    }

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
