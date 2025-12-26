using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    public GameObject fps;
    public GameObject intTex;
    public bool interactable;
    public Animator anim;
    public Vector3 vec;
    public Vector3 cev;
    public float time;

    void Update()
    {
        if (ControlFreak2.CF2Input.GetMouseButtonDown(0))
        {

            if (interactable)
            {


                    real();

                
            }
        }

    }
    void real()
    {
        interactable = false;
        fps.SetActive(false);
        intTex.SetActive(false);
        anim.SetTrigger("move");
        StartCoroutine("mo");
    }
    IEnumerator mo()
    {
        yield return new WaitForSeconds(time);
        fps.SetActive(true);
        fps.transform.position = (vec);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            interactable = true;
            intTex.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            interactable = false;
            intTex.SetActive(false);
        }
    }
}
