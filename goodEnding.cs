using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodEnding : MonoBehaviour
{
    public GameObject lc, endUI, cam;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            cam.SetActive(false);
            lc.SetActive(true);
            StartCoroutine("scene");
        }
    }
    IEnumerator scene()
    {
        yield return new WaitForSeconds(5f);
        endUI.SetActive(true);
    }
}
