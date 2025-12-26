using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class allDial : MonoBehaviour
{
    public TextMeshProUGUI but1, but2, text, tex;
    public GameObject Answer, Dial, rig;
    public string answer, dial, answer1, answer2, anser;
    public bool isTalking, ended;
    public SC_FPSController sc;
    
    void Update()
    {
        text.text = dial;
        but1.text = answer1;
        but2.text = answer2;
        if(Answer.active == true || Dial.active == true)
        {
            rig.SetActive(false);
        }



        if(isTalking == true)
        {
            ControlFreak2.CFCursor.lockState = CursorLockMode.None;
            sc.enabled = false;
        }
    }
    public void button1()
    {
        tex.text = answer;
        Dial.SetActive(false);
        Answer.SetActive(true);
        ended = true;
    }
    public void button2()
    {
        tex.text = anser;
        Dial.SetActive(false);
        Answer.SetActive(true);
        ended = true;

    }
    public void Exit()
    {
        isTalking = false;
        rig.SetActive(true);
        ended = true;
        Dial.SetActive(false);
        Answer.SetActive(false);
        ControlFreak2.CFCursor.lockState = CursorLockMode.Locked;
        sc.enabled = true;
    }
}
