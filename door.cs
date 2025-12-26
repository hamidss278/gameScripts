using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject intTex, ltex, uknown, dial, fps, cam, keyy2, item;
    public Animator anim, anom;
    public bool toggle, interactable, locked, jump, jujump, juj, keyy, ai, one;
    public string s;
    public keys sc;
    public items cs;
    public AudioSource audio;
    public bool firs, islock, sit;

    void Update()
    {

        if (interactable == true)
        {
            if (locked == false)
            {

                    if (ControlFreak2.CF2Input.GetMouseButtonDown(0))
                    {
                        if (one == true)
                        {
                            if (toggle == true)
                            {
                                toggle = true;
                            }
                        }
                        toggle = !toggle;

                        if (toggle == true)
                        {
                            if (firs == true)
                            {
                                PlayerPrefs.SetInt("beggin", 1);
                                PlayerPrefs.Save();
                            }
                            if (keyy == true)
                            {
                                keyy2.SetActive(true);
                            }
                            if (sit == true)
                            {
                                cs.inhand = false;
                                sc.pick = false;
                                item.SetActive(false);
                            }
                            anim.SetTrigger("open");
                            audio.Play();

                            if (jump == true)
                            {
                                uknown.SetActive(true);
                                if (jujump == true)
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
        if (ControlFreak2.CF2Input.GetMouseButtonDown(0))
        {

            if (locked == false)
            {

                if (interactable == true)
                {
                    if (islock == true)
                    {
                        anom.SetTrigger("locked");
                    }
                    if(islock == false)
                    {
                        anim.SetTrigger("locked");
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
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(locked == true)
            {
                if (sc.pick == true)
                {
                    locked = false;
                }
            }

            if (locked == false)
            {

                    interactable = true;
                    intTex.SetActive(true);
            }
            if (locked == true)
            {
                interactable = true;
                intTex.SetActive(false);
                ltex.SetActive(true);
            }
        }
            }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jump"))
        {
            if (locked == false)
            {
                if (ai == true)
                {
                    toggle = !toggle;
                    if (toggle == true)
                    {
                        if (firs == true)
                        {
                            PlayerPrefs.SetInt("beggin", 1);
                            PlayerPrefs.Save();
                        }
                        if (keyy == true)
                        {
                            keyy2.SetActive(true);
                        }
                        if (sit == true)
                        {
                            cs.inhand = false;
                            sc.pick = false;
                            item.SetActive(false);
                        }
                        anim.SetTrigger("open");
                        audio.Play();

                        if (jump == true)
                        {
                            uknown.SetActive(true);
                            if (jujump == true)
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
