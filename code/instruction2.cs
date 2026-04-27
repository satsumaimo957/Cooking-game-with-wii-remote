using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WiimoteApi;

public class instruction2 : MonoBehaviour
{
    private Wiimote wiimote;
    public GameObject startUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wiimote = WiimoteManager.Wiimotes[0];
        if (WiimoteManager.HasWiimote() == true && Timer.gameflag == false)
        {
            Timer.stage1 = 1;
            startUI.SetActive(true);
        }

        if (wiimote.Button.b == true && Timer.gameflag == false)
        {
            startUI.SetActive(false);
            Timer.gameflag = true;
        }
    }
}
