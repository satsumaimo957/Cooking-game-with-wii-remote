using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WiimoteApi;

public class startyazirus : MonoBehaviour
{
    private Wiimote wiimote;
    public static int optionnum;
    private bool push;

    // Start is called before the first frame update
    void Start()
    {
        push = false;
    }

    // Update is called once per frame
    void Update()
    {
        wiimote = WiimoteManager.Wiimotes[0];
        if (wiimote.Button.d_down && optionnum == 0 && !push)
        {
            this.transform.position = (new Vector3(830, 470, 0));
            optionnum = 1;
            push = true;
        }
        else if(!wiimote.Button.d_down && !wiimote.Button.d_up && optionnum == 1 && push)
        {
            push = false;
        }
        if (wiimote.Button.d_down && optionnum == 1 && !push)
        {
            this.transform.position = (new Vector3(830, 430, 0));
            optionnum = 2;
            push = true;
        }
        if (wiimote.Button.d_up && optionnum == 1 && !push)
        {
            this.transform.position = (new Vector3(830, 510, 0));
            optionnum = 0;
            push = true;
        }else if (!wiimote.Button.d_down && !wiimote.Button.d_up && optionnum == 0 && push)
        {
            push = false;
        }
        if (wiimote.Button.d_up && optionnum == 2 && !push)
        {
            this.transform.position = (new Vector3(830, 470, 0));
            optionnum = 1;
            push = true;
        }
        else if (!wiimote.Button.d_down && !wiimote.Button.d_up && optionnum == 2 && push)
        {
            push = false;
        }


        if (wiimote.Button.plus && optionnum == 0)
        {
            SceneManager.LoadScene("Game");
        }
        if (wiimote.Button.plus && optionnum == 1)
        {
            SceneManager.LoadScene("Game2");
        }
        if (wiimote.Button.plus && optionnum == 2)
        {
            SceneManager.LoadScene("howtoplay");
        }

    }

    public void option2()
    {
        SceneManager.LoadScene("howtoplay");
    }
}
