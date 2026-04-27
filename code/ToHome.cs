using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WiimoteApi;

public class ToHome : MonoBehaviour
{
    private Wiimote wiimote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wiimote = WiimoteManager.Wiimotes[0];
        if (wiimote.Button.minus)
        {
            startyazirus.optionnum = 0;
            SceneManager.LoadScene("Start");
        }
    }

    public void tohome()
    {
        SceneManager.LoadScene("Start");
    }
}
