using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fence : MonoBehaviour
{
    public Animator anim;
    public GameObject IntTex, notT;
    public bool interactable;
    public keys key;
    public BoxCollider col;

    void Update()
    {
        if(interactable == true)
        {
            if(key.pick == true)
            {
                if(ControlFreak2.CF2Input.GetMouseButtonDown(0))
                {
                    IntTex.SetActive(false);
                    anim.SetTrigger("open");
                    col.enabled = false;
                }
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            if(key.pick == false)
            {
                notT.SetActive(true);
                interactable = false;
            }
            else
            {
                IntTex.SetActive(true);
                interactable = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            notT.SetActive(false);
            interactable = false;
            IntTex.SetActive(false);
        }
    }
}
