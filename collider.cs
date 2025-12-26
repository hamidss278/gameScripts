using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    public crouching sc;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            sc.enabled = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            sc.enabled = true;
        }
    }
}
