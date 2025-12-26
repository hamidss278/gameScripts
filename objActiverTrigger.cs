using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objActiverTrigger : MonoBehaviour
{
    public GameObject ghost;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ghost.SetActive(true);
        }
    }
}
