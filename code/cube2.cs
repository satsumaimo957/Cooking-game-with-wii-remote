using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;

public class cube2 : MonoBehaviour
{
    private Wiimote wiimote;

    public bool LED1 = false;
    public bool LED2 = false;
    public bool LED3 = false;
    public bool LED4 = false;

    public int Flag = 0;

    public GameObject item;
    public GameObject position;
    public GameObject item_2;
    public GameObject position_2;
    public GameObject item_3;
    public GameObject position_3;
    public GameObject item_4;
    public GameObject position_4;

    float time;
    //float timeA;
    public static bool isSpawn;
    bool isSpawnhalf;
    int number;
    int number2;
    public static bool kitteru;
    public static int cutcnt;

    // Start is called before the first frame update
    void Start()
    {
        cutcnt = 0;
        kitteru = false;
        isSpawn = true;
        isSpawnhalf = true;
        //timeA = 3.0f;
        number = 0;
        Instantiate(item, new Vector3(position.transform.position.x,
                                    position.transform.position.y,
                                    position.transform.position.z),
                                            Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.time < 20 && Timer.gameflag == true)
        {
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

            if (accel_y > -0.6)
            {
                this.transform.position = (new Vector3((float)0, 2, 2));
                this.transform.Rotate(new Vector3(0f, 0f, 0f));
                Flag = 0;
            }
            else if (accel_y <= -0.8 && accel_x >= -0.5 && accel_x < 0.5 && Flag == 0)
            {
                this.transform.position = (new Vector3((float)0, 0, 2));
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
            //timeA -= Time.deltaTime;
            /*if (time <= 0.5 && !isSpawnhalf)
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
                GameObject[] tom = GameObject.FindGameObjectsWithTag("tomato");
                foreach (GameObject hm in tom)
                {
                    Destroy(hm);
                }*/
                /*number = Random.Range(0, item.Length);
                number2 = Random.Range(0, item.Length);*/
                /*Instantiate(item, new Vector3(position.transform.position.x,
                                        position.transform.position.y,
                                        position.transform.position.z),
                                                Quaternion.identity);
                isSpawn = true;*/
                /*if (point.ten < 10)
                {*/
                    //timeA = 3.0f;
                /*}
                else if (point.ten < 24)
                {
                    timeA = 3.0f;
                }
                else
                {
                    timeA = 3.0f;
                }*/

            //}
            /*if (timeA <= 0)
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
                    timeA = 3.0f;
                }
                else
                {
                    timeA = 3.0f;
                }
            }*/

            if(Flag==0 && kitteru == true && cutcnt==1)
            {
                GameObject[] half = GameObject.FindGameObjectsWithTag("halftomatoL");
                foreach (GameObject hm in half)
                {
                    Destroy(hm);
                }
                
                isSpawnhalf = true;
                kitteru = false;
                Instantiate(item_2, new Vector3(position_2.transform.position.x,
                                        position_2.transform.position.y,
                                        position_2.transform.position.z),
                                                Quaternion.identity);
                cutcnt = 2;

            }

            if (Flag == 0 && kitteru == true && cutcnt == 3)
            {
                GameObject[] half = GameObject.FindGameObjectsWithTag("halftomatoL");
                foreach (GameObject hm in half)
                {
                    Destroy(hm);
                }
                
                isSpawnhalf = true;
                kitteru = false;
                Instantiate(item_3, new Vector3(position_3.transform.position.x,
                                        position_3.transform.position.y,
                                        position_3.transform.position.z),
                                                Quaternion.identity);
                cutcnt = 4;

            }

            if (Flag == 0 && kitteru == true && cutcnt == 5)
            {
                GameObject[] half = GameObject.FindGameObjectsWithTag("halftomatoL");
                foreach (GameObject hm in half)
                {
                    Destroy(hm);
                }

                isSpawnhalf = true;
                kitteru = false;
                Instantiate(item_4, new Vector3(position_4.transform.position.x,
                                        position_4.transform.position.y,
                                        position_4.transform.position.z),
                                                Quaternion.identity);
                cutcnt = 6;

            }

            if (Flag == 0 && kitteru == true && cutcnt == 7)
            {
                GameObject[] half = GameObject.FindGameObjectsWithTag("halftomatoL");
                foreach (GameObject hm in half)
                {
                    Destroy(hm);
                }
                GameObject[] halfr = GameObject.FindGameObjectsWithTag("halftomato");
                foreach (GameObject hm in halfr)
                {
                    Destroy(hm);
                }
                GameObject[] halfa = GameObject.FindGameObjectsWithTag("tomato");
                foreach (GameObject hm in halfa)
                {
                    Destroy(hm);
                }

                isSpawnhalf = true;
                kitteru = false;
                Instantiate(item, new Vector3(position.transform.position.x,
                                    position.transform.position.y,
                                    position.transform.position.z),
                                            Quaternion.identity);
                cutcnt = 0;

            }
        }
    }

    public GameObject position1;
    public GameObject position2;
    public GameObject target;
    public GameObject target2;
    public GameObject position1_2;
    public GameObject position2_2;
    public GameObject target_2;
    public GameObject target2_2;
    public GameObject position1_3;
    public GameObject position2_3;
    public GameObject target_3;
    public GameObject target2_3;
    public GameObject position1_4;
    public GameObject position2_4;
    public GameObject target_4;
    public GameObject target2_4;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "tomato" && cutcnt==0)
        {
            /*if (point.ten < 10)
            {*/
                time = 2.0f;
            /*}
            else if (point.ten < 24)
            {
                time = 1.5f;
            }
            else
            {
                time = 1.0f;
            }*/
            /*if (Flag == 1)
            {*/
            isSpawn = false;
                isSpawnhalf = false;
                Destroy(collision.gameObject);
                Instantiate(target, new Vector3(position1.transform.position.x,
                                               position1.transform.position.y,
                                               position1.transform.position.z),
                                               Quaternion.Euler(0, 0, 0));
                Instantiate(target2, new Vector3(position2.transform.position.x,
                                               position2.transform.position.y,
                                               position2.transform.position.z),
                                               Quaternion.Euler(0, 0, 0));
            kitteru = true;
            cutcnt=1;
            //}
        }

        if (collision.gameObject.tag == "tomato" && cutcnt == 2)
        {
            /*if (point.ten < 10)
            {*/
            time = 2.0f;
            /*}
            else if (point.ten < 24)
            {
                time = 1.5f;
            }
            else
            {
                time = 1.0f;
            }*/
            /*if (Flag == 1)
            {*/
            isSpawn = false;
            isSpawnhalf = false;
            Destroy(collision.gameObject);
            Instantiate(target_2, new Vector3(position1_2.transform.position.x,
                                           position1_2.transform.position.y,
                                           position1_2.transform.position.z),
                                           Quaternion.Euler(0, 0, 0));
            Instantiate(target2_2, new Vector3(position2_2.transform.position.x,
                                           position2_2.transform.position.y,
                                           position2_2.transform.position.z),
                                           Quaternion.Euler(0, 0, 0));
            kitteru = true;
            cutcnt=3;
            //}
        }

        if (collision.gameObject.tag == "tomato" && cutcnt == 4)
        {
            /*if (point.ten < 10)
            {*/
            time = 2.0f;
            /*}
            else if (point.ten < 24)
            {
                time = 1.5f;
            }
            else
            {
                time = 1.0f;
            }*/
            /*if (Flag == 1)
            {*/
            isSpawn = false;
            isSpawnhalf = false;
            Destroy(collision.gameObject);
            Instantiate(target_3, new Vector3(position1_3.transform.position.x,
                                           position1_3.transform.position.y,
                                           position1_3.transform.position.z),
                                           Quaternion.Euler(0, 0, 0));
            Instantiate(target2_3, new Vector3(position2_3.transform.position.x,
                                           position2_3.transform.position.y,
                                           position2_3.transform.position.z),
                                           Quaternion.Euler(0, 0, 0));
            kitteru = true;
            cutcnt = 5;
            //}
        }

        if (collision.gameObject.tag == "tomato" && cutcnt == 6)
        {
            /*if (point.ten < 10)
            {*/
            time = 2.0f;
            /*}
            else if (point.ten < 24)
            {
                time = 1.5f;
            }
            else
            {
                time = 1.0f;
            }*/
            /*if (Flag == 1)
            {*/
            isSpawn = false;
            isSpawnhalf = false;
            Destroy(collision.gameObject);
            Instantiate(target_4, new Vector3(position1_4.transform.position.x,
                                           position1_4.transform.position.y,
                                           position1_4.transform.position.z),
                                           Quaternion.Euler(0, 0, 0));
            Instantiate(target2_4, new Vector3(position2_4.transform.position.x,
                                           position2_4.transform.position.y,
                                           position2_4.transform.position.z),
                                           Quaternion.Euler(0, 0, 0));
            kitteru = true;
            cutcnt = 7;
            //}
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
