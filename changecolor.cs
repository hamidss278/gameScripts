using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changecolor : MonoBehaviour
{
    public RawImage i1, i2, i3, i4;
    public shop sc;
    public Color col;

    void Update()
    {
        if(PlayerPrefs.GetInt("levelspeed") == 1)
        {
            i1.color = col;
        }
        if (PlayerPrefs.GetInt("levelspeed") == 2)
        {
            i2.color = col;
        }
        if (PlayerPrefs.GetInt("levelspeed") == 3)
        {
            i3.color = col;
        }
        if (PlayerPrefs.GetInt("levelspeed") == 4)
        {
            i4.color = col;
        }
    }
}
