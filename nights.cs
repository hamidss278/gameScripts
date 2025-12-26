using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nights : MonoBehaviour
{
    public GameObject night2, night3, night4, fps, up, deadcut;
    public bool died, night2b, night3b, night4b;
    public PlayerHealth sc;
    public Animator anim;
    public SC_FPSController scc;

    void Update()
    {
        if (died == true)
        {
            fps.SetActive(false);
        }
        if (died == true)
        {
            deadcut.SetActive(true);
            scc.enabled = false;
        }
    }
}
