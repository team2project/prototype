using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    //public GameObject camera;
    //private int dx;
    //private int dy;

    //public ParticleSystem rainParticle;    //雨のParticleSystemを管理
    //public ParticleSystem snowParticle;    //雪のParticleSystemを管理

    // Start is called before the first frame update
    /*void Start()
    {
        dx = 0;
        dy = 0;
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

    /*private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスクリック開始(マウスダウン)時にカメラの角度を保持(Z軸には回転させないため).
            newAngle = Camera.main.transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // マウスの移動量分カメラを回転させる.
            newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
            newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
            Camera.main.gameObject.transform.localEulerAngles = newAngle;

            lastMousePosition = Input.mousePosition;
        }

    }*/
}
