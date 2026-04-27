using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WiimoteApi;

public class wiiconcheck : MonoBehaviour
{
    private Wiimote wiimote;
    public GameObject wiicheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WiimoteManager.HasWiimote() == true)
        {
            wiicheck.SetActive(false);
        }
    }

    public void option2()
    {
        SceneManager.LoadScene("howtoplay");
    }
}
