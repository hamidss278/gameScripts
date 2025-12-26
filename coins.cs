using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coins : MonoBehaviour
{
    public bool finished, coina;
    public TextMeshProUGUI tex;
    public int coin;
    

    void Update()
    {
        coin = PlayerPrefs.GetInt("coin");
        tex.text = coin.ToString();
        if(finished == true)
        {
             PlayerPrefs.SetInt("coin", + 1200);
            coina = true;
        }
        if(coina == true)
        {
            finished = false;
        }
    }
}
