using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    public GameObject flashh, flashg, intTex;
    public bool interactable;

    void Update()
    {
        if(ControlFreak2.CF2Input.GetMouseButtonDown(0))
        {
            if(interactable == true)
            {
                flashh.SetActive(true);
                flashg.SetActive(false);
                intTex.SetActive(false);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intTex.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intTex.SetActive(false);
            interactable = false;
        }
    }
}
