using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{
    public GameObject note;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
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
