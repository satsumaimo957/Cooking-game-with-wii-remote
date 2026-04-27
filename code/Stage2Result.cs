using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WiimoteApi;

public class Stage2Result : MonoBehaviour
{
    private int nowScore;
    public Text NowTen2;
    public GameObject resultUI2;
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
        if (Timer.stage1 == 1)
        {
            if (Timer.time >= 20)
            {
                resultUI2.SetActive(true);
                nowScore = point.ten;
                NowTen2.text = "合計スコア:" + nowScore;
                if (wiimote.Button.b == true && Timer.gameflag == true)
                {
                    Timer.stage1 = 0;
                    SceneManager.LoadScene("Start");
                    Timer.gameflag = false;
                }
            }
        }
    }
}
