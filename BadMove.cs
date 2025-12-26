using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMove : MonoBehaviour
{
    public GameObject up, p, fp, fade, fade2, can1, can2, tr1, tr2, pre, ra;
    public Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            fp.SetActive(false);
            can1.SetActive(false);
            can2.SetActive(true);
            fade.SetActive(true);
            anim.SetTrigger("View");
            StartCoroutine("o");
        }
    }
    IEnumerator o()
    {
        yield return new WaitForSeconds(6f);
        tr1.SetActive(false);
        tr2.SetActive(false);
        pre.SetActive(true);
        ra.SetActive(true);
        up.SetActive(true);
        p.SetActive(false);
        fp.SetActive(false);
        fade2.SetActive(true);
    }
}
