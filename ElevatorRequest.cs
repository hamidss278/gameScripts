using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRequest : MonoBehaviour
{
    public Animator anim, anima;
    public door cc;
    public bool interact, locked;
    public GameObject IntTex, ltex;
    public Generator cs;
    public elevator sc;

    void Update()
    {
        if (ControlFreak2.CF2Input.GetMouseButtonDown(0))
        {
            if (interact == true)
            {
               if ( sc.toggle ==true)
                {
                   if(locked == false)
                   {


                           anima.SetTrigger("down");
                           anim.SetTrigger("button");
                           sc.toggle = false;
                           sc.finished = false;
                           sc.canInt = false;
                           sc.StartCoroutine("elvetaor");

                   }


                }

            }
        }
        if(cs.isTrue == true)
        {
            if(cc.toggle == true)
            {
                locked = false;
            }

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            
            if(locked == true)
            {
                ltex.SetActive(true);
            }
            else
            {
                interact = true;
                IntTex.SetActive(true);
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interact = false;
            IntTex.SetActive(false);
            ltex.SetActive(false);
        }
    }
}
