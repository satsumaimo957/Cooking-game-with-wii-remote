using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WiimoteApi;

public class Stage1Result : MonoBehaviour
{
    private int nowScore;
    public Text NowTen;
    public GameObject resultUI;
    private Wiimote wiimote;
    // Start is called before the first frame update
    void Start()
    {
        nowScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        wiimote = WiimoteManager.Wiimotes[0];
        if (Timer.stage1 == 0)
        {
            if (Timer.time >= 50)
            {
                resultUI.SetActive(true);
                nowScore = point.ten;
                NowTen.text = "åªç›ÇÃÉXÉRÉA:" + nowScore;
                if (wiimote.Button.a == true && Timer.gameflag == true)
                {
                    Timer.stage1 = 1;
                    SceneManager.LoadScene("Game2");
                    Timer.gameflag = false;
                }
            }
        }
    }

    public void GoNext()
    {
         SceneManager.LoadScene("Game2");
    }
}
