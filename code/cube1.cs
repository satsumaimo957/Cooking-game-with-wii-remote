using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;

public class cube1 : MonoBehaviour
{
    private Wiimote wiimote;

    public bool LED1 = false;
    public bool LED2 = false;
    public bool LED3 = false;
    public bool LED4 = false;

    int Flag = 0;

    public GameObject[]item;
    public GameObject[]position;
    float time;
    float timeA;
    public static bool isSpawn;
    bool isSpawnhalf;
    int number;
    int number2;

    // Start is called before the first frame update
    void Start()
    {
        isSpawn = true;
        isSpawnhalf = true;
        timeA = 3.0f;
        number = 0;
        Instantiate(item[0], new Vector3(position[number].transform.position.x,
                                    position[number].transform.position.y,
                                    position[number].transform.position.z),
                                            Quaternion.identity);
        isFood = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.time < 50 && Timer.gameflag==true) { 
            if (!WiimoteManager.HasWiimote()) { return; }
            wiimote = WiimoteManager.Wiimotes[0];/*
                float accel_x;
                float accel_y;
                float accel_z;

                float[]accel = wiimote.Accel.GetCalibrateAccelData();
                accel_x=accel[0];
                accel_y=accel[2];
                accel_z=accel[1];
                transform.Translate(new Vector3(accel_x,accel_y,accel_z),normalized);
                */
            wiimote.SendPlayerLED(LED1, LED2, LED3, LED4);

            /*if (wiimote.Button.a == true)
            {
                Flag = 1;
            }*/
            /*else if (wiimote.Button.b == true) { }*/
            float[] accel = wiimote.Accel.GetCalibratedAccelData();
            float accel_x = accel[0];
            float accel_y = -accel[2];
            float accel_z = -accel[1];

            if (accel_y > -0.60)
            {
                this.transform.position = (new Vector3((float)0, 2, 2));
                this.transform.Rotate(new Vector3(0f, 0f, 0f));
                Flag = 0;
            }
            else if (accel_y <= -0.80 && accel_x >= -0.5 && accel_x < 0.5 && Flag == 0)
            {
                this.transform.position = (new Vector3((float)0, 0, 2));
                this.transform.Rotate(new Vector3(0f, 0f, 0f));
                Flag = 1;
            }
            else if (accel_y <= -0.80 && accel_x < -0.8 && Flag == 0)
            {
                this.transform.position = (new Vector3((float)3.2, 0, 2));
                this.transform.Rotate(new Vector3(0f, 0f, 0f));
                Flag = 1;
            }
            else if (accel_y <= -0.80 && accel_x > 0.8 && Flag == 0)
            {
                this.transform.position = (new Vector3((float)-3.2, 0, 2));
                this.transform.Rotate(new Vector3(0f, 0f, 0f));
                Flag = 1;
            }
            /*if (accel_y > 0 || accel_y < 1.0)
            {
                transform.Rotate(0f,-1f * accel_y,0f);
            }*/
            //transform.RotateAround(new Vector3(0,0,0),new Vector3(1,0,0),1);
            /* }*/
            //-200kara-40
            /*float currentXAngle = transform.eulerAngles.x;
              if (currentXAngle<90 || currentXAngle>180)
              {
                  accel_y = 0;
              }*/

            //transform.Rotate(new Vector3(0, -accel_y, 0));

            time -= Time.deltaTime;
            timeA -= Time.deltaTime;
            if (time <= 0.5 && !isSpawnhalf)
            {
                GameObject[] half = GameObject.FindGameObjectsWithTag("halftomato");
                foreach (GameObject hm in half)
                {
                    Destroy(hm);
                }
                isSpawnhalf = true;
            }
            if (time <= 0 && !isSpawn)
            {
                if (point.ten < 10)
                {
                    timeA = 3.0f;
                }
                else if (point.ten < 24)
                {
                    timeA = 2.0f;
                }
                else
                {
                    timeA = 1.0f;
                }
                GameObject[] tom = GameObject.FindGameObjectsWithTag("tomato");
                foreach (GameObject hm in tom)
                {
                    Destroy(hm);
                }
                number = Random.Range(0, item.Length);
                number2 = Random.Range(0, item.Length);
                Instantiate(item[number], new Vector3(position[number2].transform.position.x,
                                        position[number2].transform.position.y,
                                        position[number2].transform.position.z),
                                                Quaternion.identity);
                isSpawn = true;
                if (point.ten < 10)
                {
                    timeA = 3.0f;
                }
                else if (point.ten < 24)
                {
                    timeA = 2.0f;
                }
                else
                {
                    timeA = 1.0f;
                }

            }
            if (timeA <= 0)
            {
                GameObject[] tom = GameObject.FindGameObjectsWithTag("tomato");
                foreach (GameObject hm in tom)
                {
                    Destroy(hm);
                }
                number = Random.Range(0, item.Length);
                number2 = Random.Range(0, item.Length);
                Instantiate(item[number], new Vector3(position[number2].transform.position.x,
                                        position[number2].transform.position.y,
                                        position[number2].transform.position.z),
                                                Quaternion.identity);
                isSpawn = true;
                if (point.ten < 10)
                {
                    timeA = 3.0f;
                }
                else if (point.ten < 24)
                {
                    timeA = 2.0f;
                }
                else
                {
                    timeA = 1.0f;
                }
            }
        }
    }

    public GameObject[]position1;
    public GameObject[]position2;
    public GameObject[]target;
    public GameObject[]target2;
    public static bool isFood;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "tomato")
        {
            if (collision.gameObject.name == "pan(Clone)")
            {
                isFood = false;
            }
            else
            {
                isFood = true;
            }
            if (point.ten < 6)
            {
                time = 2.0f;
            }
            else if (point.ten < 16)
            {
                time = 1.5f;
            }
            else
            {
                time = 1.0f;
            }
            isSpawn = false;
            isSpawnhalf = false;
            Destroy(collision.gameObject);
            Instantiate(target[number], new Vector3(position1[number2].transform.position.x,
                                           position1[number2].transform.position.y,
                                           position1[number2].transform.position.z),
                                           Quaternion.Euler(0, 90, 0));
            Instantiate(target2[number], new Vector3(position2[number2].transform.position.x,
                                           position2[number2].transform.position.y,
                                           position2[number2].transform.position.z),
                                           Quaternion.Euler(0, -90, 0));
        }
    }

    

    /*private void newfruit()
    {
        public GameObject saiki;
        public GameObject positionsaiki;

        Instantiate(saiki, new Vector3(positionsaiki.transform.position.x,
                                    positionsaiki.transform.position.y,
                                    positionsaiki.transform.position.z),
                                            Quaternion.identity);
        
    }*/

    /*public int flag()
    {
        if (Flag == 1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }*/
}
