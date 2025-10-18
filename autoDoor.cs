using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDoor : MonoBehaviour
{
    public Animator anim; //animation you make in game



    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // make sure to change the player tag to Player
        {
            anim.SetTrigger("open");
        }
        if (other.CompareTag("Ai")) // if you had an ai in your game this will work i recommend to not touch it
        {
            anim.SetTrigger("open");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("close");
        }
        if (other.CompareTag("Ai"))
        {
            anim.SetTrigger("close");
        }
    }
}
