using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstScene : MonoBehaviour
{
    public GameObject fps, cut, car, on;
    void Start()
    {
        StartCoroutine("firstcut");
    }
    IEnumerator firstcut()
    {
        yield return new WaitForSeconds(17f);
        fps.SetActive(true);

        cut.SetActive(false);
        car.SetActive(true);
    }
}
