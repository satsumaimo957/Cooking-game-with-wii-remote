using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WiimoteApi;

public class tomato : MonoBehaviour
{
    private Wiimote wiimote;
    float time;
    bool isSpawn;
    // Start is called before the first frame update
    void Start()
    {
        isSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*time += Time.deltaTime;
        int t = Mathf.FloorToInt(time);*/
        /*if (wiimote.Button.a == true)
        {
            Instantiate(saiki, new Vector3(positionsaiki.transform.position.x,
                                positionsaiki.transform.position.y,
                                positionsaiki.transform.position.z),
                                            Quaternion.identity);
        }*/
        time -= Time.deltaTime;
        if (time <= 0 && !isSpawn)
        {
            GameObject[] half = GameObject.FindGameObjectsWithTag("halftomato");
            foreach(GameObject hm in half)
            {
                Destroy(hm);
            }
            isSpawn = true;
        }
    }

    public GameObject position;
    public GameObject position2;
    public GameObject target;
    public GameObject target2;
    cube1 c1;
    int num;
    //public GameObject saiki;
    //public GameObject positionsaiki;
   
    private void OnCollisionEnter(Collision collision)
    {
        //num = c1.number2;
        /*if (!WiimoteManager.HasWiimote()) { return; }
        wiimote = WiimoteManager.Wiimotes[0];*/
        if (collision.gameObject.name == "knife")
        {
            Destroy(this.gameObject);
            Instantiate(target, new Vector3(position.transform.position.x,
                                           position.transform.position.y,
                                           position.transform.position.z),
                                           Quaternion.Euler(0,90,0));
            Instantiate(target2, new Vector3(position2.transform.position.x,
                                           position2.transform.position.y,
                                           position2.transform.position.z),
                                           Quaternion.Euler(0, -90, 0));
            /*if (wiimote.Button.a == true)
             { 
                Instantiate(saiki, new Vector3(positionsaiki.transform.position.x,
                                    positionsaiki.transform.position.y,
                                    positionsaiki.transform.position.z),
                                                Quaternion.identity);
            }*/
            //Invoke(nameof(newTomato), 3f);
            time = 1.0f;
            isSpawn = false;
        }
    }

    /*private void newTomato()
    {
        Instantiate(saiki, new Vector3(positionsaiki.transform.position.x,
                                    positionsaiki.transform.position.y,
                                    positionsaiki.transform.position.z),
                                                Quaternion.Euler(0,0,0));
    }*/
}
