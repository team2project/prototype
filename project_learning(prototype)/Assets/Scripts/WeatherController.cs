using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    //private CSVReader csvReader;
    
    //public ParticleSystem rainParticle;    //雨のParticleSystemを管理
    //public ParticleSystem snowParticle;    //雪のParticleSystemを管理

    // Start is called before the first frame update
    void Start()
    {
        //csvReader= new CSVReader();
    }

    public void ChangeRainStrength(float fallAmount)
    {

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
