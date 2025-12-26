using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monCrouch : MonoBehaviour
{
    public Animator anim;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Jump"))
        {
            anim.SetTrigger("crouch");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jump"))
        {
            anim.SetTrigger("walk");
        }
    }
}
