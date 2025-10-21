using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodyTrace : MonoBehaviour
{
    public GameObject foot;
    public Transform foottrace;
    public bool trace, eb;
    void Update()
    {
        if(trace == true)
        {
            Instantiate(foot, foottrace.position, foottrace.rotation);

            trace = false;
            StartCoroutine("tracess");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            eb = false;
            StartCoroutine("tracess");
            StartCoroutine("traces");
        }
    }
    IEnumerator traces()
    {
        yield return new WaitForSeconds(3f);
        trace = false;
        eb = true;
    }
    IEnumerator tracess()
    {
        yield return new WaitForSeconds(2f);
        if (eb == false)
        {
            trace = true;
            StartCoroutine("tracess");
        }
        
    }
}
