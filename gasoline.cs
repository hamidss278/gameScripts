using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gasoline : MonoBehaviour
{
    public GameObject gas, inttex, gastex, slid;
    public bool gascomp, interactable, gasin;
    public Slider slide;
    public keys gass;
    public SC_FPSController sc;
    public MainTire cc;
    public items item;
    public Animator buk;

    void Update()
    {
        if (gasin == false)
        {
            if (interactable == true)
            {
                if (ControlFreak2.CF2Input.GetMouseButton(0))
                {
                    if (gass.pick == true)
                    {
                        buk.SetTrigger("open");
                        slid.SetActive(true);
                        inttex.SetActive(false);
                        slide.value += 1;
                    }

                }
            }
            if (slide.value == 100)
            {
                cc.a5 = true;   
                buk.ResetTrigger("open");
                buk.SetTrigger("close");
                gascomp = true;
                slid.SetActive(false);
                interactable = false;
                gasin = true;

            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (gasin == false)
        {
            if (other.CompareTag("MainCamera"))
            {
                if (gass.pick == true)
                {
                    inttex.SetActive(true);
                    interactable = true;
                }
                else
                {
                    interactable = false;
                    gastex.SetActive(true);

                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (gasin == false)
        {
            if (other.CompareTag("MainCamera"))
            {
                slid.SetActive(false);
                interactable = false;
                gastex.SetActive(false);
                inttex.SetActive(false);
            }
        }
    }

}
