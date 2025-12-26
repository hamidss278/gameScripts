using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public PlayerHealth sc;
    public Animator anim;
    public bool can;

    void Update()
    {
        if(sc.health <=0)
        {
            if(can == true)
            {
                anim.SetTrigger("hit");
                can = false;
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            sc.health -= 20;
            can = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sc.health -= 20*Time.deltaTime  ;
        }
    }
}
