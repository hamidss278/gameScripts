using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour
{
    public GameObject Cut, intTex, ltex, fps, titr;
    public bool interactable, locked;
    public float time;
    public MainTire sc;
    public keys cs;

    void Update()
    {
        if(ControlFreak2.CF2Input.GetMouseButtonDown(0))
        {
            if(interactable == true)
            {
                if(sc.done == true)
                {
                    PlayerPrefs.SetInt("run", 1);
                    fps.SetActive(false);
                    Cut.SetActive(true);
                    titr.SetActive(true);
                    StartCoroutine("end");
                }

            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            if(cs.pick == true)
            {
                locked = false;
            }
            if(locked == true)
            {
                ltex.SetActive(true);
            }
            if(locked == false)
            {
                intTex.SetActive(true);
                interactable = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
                intTex.SetActive(false);
                interactable = false;
                ltex.SetActive(false);
        }
    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
