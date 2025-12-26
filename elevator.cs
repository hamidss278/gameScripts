using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public Animator anim;
    public bool interactable;
    public Generator sc;
    public GameObject intex, ltex;
    public int floor;
    public door cc;
    public bool finished, toggle, canInt, locked;

    void Start ()
    {
        canInt = true;
    }
    void Update()
    {
        if (ControlFreak2.CF2Input.GetMouseButtonDown(0))
        {
            
            if (interactable == true)
            {
                if (locked == false)
                {
                    toggle = !toggle;
                    if (toggle == true)
                    {
                        canInt = false;
                        StartCoroutine("elvetaor");
                        anim.SetTrigger("up");
                        interactable = false;
                        intex.SetActive(false);
                        if (finished == true)
                        {
                            floor = 2;
                            finished = false;
                        }
                    }
                    if (toggle == false)
                    {
                        canInt = false;
                        StartCoroutine("elvetaor");
                        anim.SetTrigger("down");
                        interactable = false;
                        intex.SetActive(false);
                        floor = 1;
                        if (finished == true)
                        {
                            floor = 1;
                            finished = false;
                        }
                    }
                }
                
            }
        }
        if(sc.isTrue)

        {
            if(cc.toggle == true)
            {
                locked = false;
            }

        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            if(locked == true)
            {
                ltex.SetActive(true);
            }
            if(locked == false)
            {
                if (canInt == true)
                {
                    interactable = true;
                    intex.SetActive(true);
                }
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactable = false;
            intex.SetActive(false);
            ltex.SetActive(false);
        }
    }
    IEnumerator elvetaor()
    {
        yield return new WaitForSeconds(12f);
        canInt = true;
        finished = true;
    }
}
