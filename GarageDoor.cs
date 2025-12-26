using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    public GameObject intTex, ltex, uknown, dial, fps, cam;
    public Animator anim, anom;
    public bool toggle, interactable, locked, jump, jujump, juj;
    public string s;
    public keys sc;
    public AudioSource audio;
    public bool firs;

    void Update()
    {

        if (interactable == true)
        {
            if(locked == false)
            {

                if (ControlFreak2.CF2Input.GetMouseButtonDown(0))
                {
                    toggle = !toggle;

                    if (toggle == true)
                    {
                        if (firs == true)
                        {
                            if (PlayerPrefs.GetInt("beggin") == 0)
                            {
                                PlayerPrefs.SetInt("beggin", 1);
                                PlayerPrefs.Save();
                            }
                        }
                        anim.SetTrigger("open");
                        audio.Play();

                        if(jump == true)
                        {
                            uknown.SetActive(true);
                            if(jujump == true)
                            {
                                dial.SetActive(true);
                                juj = true;
                            }
                        }
                    }
                    if (toggle == false)
                    {
                        anim.SetTrigger("close");
                        audio.Play();

                    }
                }
            }
        }
        if(juj == true)
        {
            if (dial.active == false)
            {
                cam.SetActive(true);
                fps.SetActive(false);
                anom.SetTrigger("jump");
            }
        }
        if(sc.pick == true)
        {
            locked = false;
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (locked == false)
            {

                    interactable = true;
                    intTex.SetActive(true);
            }
            if (locked == true)
            {
                intTex.SetActive(false);
                ltex.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactable = false;
            intTex.SetActive(false);
            ltex.SetActive(false);
        }
    }

    
}
