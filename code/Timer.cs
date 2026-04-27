using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WiimoteApi;

public class Timer : MonoBehaviour
{
    public static float time;
    public static bool gameflag;
    public static int stage1;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        gameflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WiimoteManager.HasWiimote() == true && gameflag==true)
        {
            time += Time.deltaTime;
        }
        if (stage1 == 0)
        {
            if (time >= 50)
            {
                time = 50;
            }
        }
        else
        {
            if (time >= 20)
            {
                time = 20;
            }
        }
        
        int t = Mathf.FloorToInt(time);
        Text uiText = GetComponent<Text>();
        if (stage1 == 0)
        {
            uiText.text = "Time:" + (50 - t);
        }
        else
        {
            uiText.text = "Time:" + (20 - t);
        }
        
    }
}
