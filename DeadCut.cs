using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCut : MonoBehaviour
{
    public GameObject ended;

    void Start()
    {
        StartCoroutine("end");
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(3.4f);
        ended.SetActive(true);
    }
    
}
