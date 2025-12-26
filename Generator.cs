using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject IntTex, ltex, fuse, cam, fps;
    public List<GameObject> lights;
    public keys sc;
    public items cs;
    public bool interactable, locked;
    public AudioSource audio;
    public bool isTrue;

    void Update()
    {
        if(ControlFreak2.CF2Input.GetMouseButtonDown(0))
        {
            if(interactable == true)
            {
                if(locked == false)
                {
                    PlayerPrefs.SetInt("lantern", 1);
                    cam.SetActive(true);
                    fps.SetActive(false);
                    StartCoroutine("S");
                    StartCoroutine("j");

                    audio.enabled = true;
                    fuse.SetActive(false);
                    isTrue = true;
                    IntTex.SetActive(false);
                    cs.inhand = false;
                }

            }
        }
        if(sc.pick == true)
        {
            locked = false;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            if(locked == true)
            {
                ltex.SetActive(true);
            }
            else
            {
                interactable = true;
                IntTex.SetActive(true);
            }

            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactable = false;
            IntTex.SetActive(false);
            ltex.SetActive(false);
        }
    }
    IEnumerator S()
    {
        yield return new WaitForSeconds(3f);
        foreach (GameObject obj in lights)
        {
            obj.SetActive(true);
        }
    }
    IEnumerator j()
    {
        yield return new WaitForSeconds(6f);
        cam.SetActive(false);
        fps.SetActive(true);
        this.enabled = false;
    }
}
