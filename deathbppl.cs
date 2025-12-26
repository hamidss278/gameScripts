using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathbppl : MonoBehaviour
{
    public Animator anim;
    public keys sc;
    public bool toggle;
    public SC_FPSController cs;
    public GameObject death;

    void Update()
    {
        if(sc.pick == true)
        {
            if (ControlFreak2.CF2Input.GetKeyDown("[5]"))
            {
                toggle =!toggle;
            }
            if(toggle == true)
            {
                death.SetActive(true);
                cs.enabled = false;
                ControlFreak2.CFCursor.visible = true;
                ControlFreak2.CFCursor.lockState = CursorLockMode.None;
                anim.SetTrigger("open");
            }
            if(toggle == false)
            {
                cs.enabled = true;
                ControlFreak2.CFCursor.visible = false;
                ControlFreak2.CFCursor.lockState = CursorLockMode.Locked;
                anim.SetTrigger("close");
                death.SetActive(false);
            }
            
        }
    }
}
