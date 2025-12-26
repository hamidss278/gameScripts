using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using RTLTMPro;

public class forestart : MonoBehaviour
{
    public GameObject diff, menu, menu1, menu2, menu3, menu4, menu5;
    public int easy, med, hard, prac;
    public RTLTextMeshPro tex;
    public Button but;

    void Start()
    {
        if(PlayerPrefs.GetInt("easy") == 1)
        {
            easy = 1;
            but.interactable = true;
        }
        if (PlayerPrefs.GetInt("med") == 1)
        {
            med = 1;
            but.interactable = true;
        }
        if (PlayerPrefs.GetInt("hard") == 1)
        {
            hard = 1;
            but.interactable = true;
        }
        if (PlayerPrefs.GetInt("prac") == 1)
        {
            prac = 1;
            but.interactable = true;
        }
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("easy") == 1)
        {
            easy = 1;
            but.interactable = true;
        }
        if (PlayerPrefs.GetInt("med") == 1)
        {
            med = 1;
            but.interactable = true;
        }
        if (PlayerPrefs.GetInt("hard") == 1)
        {
            hard = 1;
            but.interactable = true;
        }
        if (PlayerPrefs.GetInt("prac") == 1)
        {
            prac = 1;
            but.interactable = true;
        }
        PlayerPrefs.SetInt("easy", easy);
        PlayerPrefs.SetInt("med", med );
        PlayerPrefs.SetInt("hard", hard );
        PlayerPrefs.SetInt("prac", prac);
        PlayerPrefs.Save();
        if (easy == 1)
        {
            tex.text     = "آسون";
        }
        if (med == 1)
        {
            tex.text = "متوسط";
        }
        if (hard == 1)
        {
            tex.text = "سخت";
        }
        if (prac == 1)
        {
            tex.text = "تمرین";
        }
    }
    public void Open()
    {
        diff.SetActive(true);
        menu.SetActive(false);
        menu1.SetActive(false);
        menu2.SetActive(false);
        menu3.SetActive(false);
        menu4.SetActive(false);
        menu5.SetActive(false);
    }
    public void eas()
    {
        easy = 1;
        med = 0;
        hard = 0;
        prac = 0;

        PlayerPrefs.SetInt("easy", 1);
        PlayerPrefs.SetInt("med", 0);
        PlayerPrefs.SetInt("hard", 0);
        PlayerPrefs.SetInt("prac", 0);
        PlayerPrefs.Save();
    }
        public void medd()
    {
        easy = 0;
        med = 1;
        hard = 0;
        prac = 0;

        PlayerPrefs.SetInt("easy", 0);
        PlayerPrefs.SetInt("med", 1);
        PlayerPrefs.SetInt("hard", 0);
        PlayerPrefs.SetInt("prac", 0);
        PlayerPrefs.Save();
        }

            public void hardd()
    {
        easy = 0;
        med = 0;
        hard = 1;
        prac = 0;
        PlayerPrefs.SetInt("easy", 0);
        PlayerPrefs.SetInt("med", 0);
        PlayerPrefs.SetInt("hard", 1);
        PlayerPrefs.SetInt("prac", 0);
        PlayerPrefs.Save();
            }
            public void pract()
            {
                easy = 0;
                med = 0;
                hard = 0;
                prac = 1;
                PlayerPrefs.SetInt("easy", 0);
                PlayerPrefs.SetInt("med", 0);
                PlayerPrefs.SetInt("hard", 0);
                PlayerPrefs.SetInt("prac", 1);

                PlayerPrefs.Save();
            }
}
