using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class point : MonoBehaviour
{
    public static int ten;
    int tasu;
    // Start is called before the first frame update
    void Start()
    {
        if (ten != 0)
        {
            if (Timer.stage1 == 0)
            {
                ten = 0;
            }
        }
        else
        {
            ten = 0;
        }
        tasu = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Timer.stage1 == 0)
        {
            if (cube1.isSpawn == false)
            {
                if (cube1.isFood == false)
                {
                    tasu = -3;
                }
                else
                {
                    tasu = 2;
                }

            }
            else
            {
                if (tasu != 0)
                {
                    ten = ten + tasu;
                    tasu = 0;
                }
            }
        }
        else
        {
            if (cube2.kitteru == true)
            {
                if (cube2.cutcnt == 7)
                {
                    tasu = 3;
                }
            
            }
            else
            {
                if (tasu != 0)
                {
                    ten = ten + tasu;
                    tasu = 0;
                }
            }
        }


        if (ten < 0)
        {
            ten = 0;
        }

        Text uiText = GetComponent<Text>();
        uiText.text = "Point:" + ten;
    }

}
