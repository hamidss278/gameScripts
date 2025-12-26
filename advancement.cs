using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class advancement : MonoBehaviour
{
    public GameObject beggin, run, lantern, scream;
    public GameObject check1, check2, check3, check4;
    public bool menu, game;
    void Update()
    {
        if(PlayerPrefs.GetInt("beggin") == 1)
        {

            if(menu == true)
            {
                check1.SetActive(true);
            }

            if(game == true)
            {
                beggin.SetActive(true);
            }


        }
        if(PlayerPrefs.GetInt("run") == 1)
        {

            if(menu == true)
            {
                check2.SetActive(true);
            }

            if (game == true)
            {
                run.SetActive(true);
            }


        }
        if(PlayerPrefs.GetInt("lantern") == 1)
        {

            if(menu == true)
            {
                check3.SetActive(true);
            }

            if(game == true)
            {
                lantern.SetActive(true);
            }


        }
        if(PlayerPrefs.GetInt("scream") == 1)
        {

            if(menu == true)
            {
                check4.SetActive(true);
            }

            if(game == true)
            {
                scream.SetActive(true);
            }

        }
    }
}
