using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animTrigger : MonoBehaviour
{
    public Animator anim;
    public string theAnim;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger(theAnim);
        }
    }
}
