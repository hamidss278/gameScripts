using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    public int itemCounts;
    public int needed;
    public GameObject apartment;


    void Update()
    {
        if(itemCounts == needed)
        {
            apartment.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Brick"))
        {
            itemCounts += 1;
            other.gameObject.SetActive(false);
            
        }
    }
}
