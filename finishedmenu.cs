using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishedmenu : MonoBehaviour
{
    public bool f;

    void Start()
    {
        if(PlayerPrefs.GetInt("finished") == 1)
        {
            SceneManager.LoadScene("Finished");
        }
    }
    void Update()
    {
        if(f == true)
        {
            PlayerPrefs.SetInt("finished", 1);
        }
        else
        {
            PlayerPrefs.SetInt("finished", 0);
        }
    }
}
