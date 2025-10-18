using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{
    public GameObject note; // the image that you want to be shown when looking at something

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera")) // make a collider for your camera and allign it and then change the camera tag to MainCamera
        {
            note.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            note.SetActive(false);  
        }
    }
}
