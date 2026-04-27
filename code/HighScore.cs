using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private int highscore;
    public Text bestTen;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highscore = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bestTen.text = "HighScore:" + highscore;

        if (Timer.stage1 == 1)
        {
            if (Timer.time >= 20)
            {
                if (point.ten > highscore)
                {
                    PlayerPrefs.SetInt("HighScore", point.ten);
                }
            }
        }
    }
}
