using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keys : MonoBehaviour
{
    public GameObject key, intTex;
    public bool interactable, pick, ifneed, n, m;
    public AudioSource audio;
    public Transform cam;
    public items sc;
    public door cc;
    public Rigidbody Rigid;
    public Vector3 vec, vec2;
    public TextMeshProUGUI tex;
    public string emty;

    void Update()
    {
        if(m == true)
        {
            if(cc.toggle == true)
            {
                n = false;
            }
            if(cc.toggle == false)
            {
                n = true;
            }
        }
        if(pick == true)
        {
            interactable = false;
            intTex.SetActive(false);
        }
        if(ControlFreak2.CF2Input.GetMouseButtonDown(0))
        {
            if(interactable == true)
            {
                if (sc.inhand == false)
                {
                    if (ifneed == true)
                    {
                        tex.text = key.name;
                    }

                    if(n == false)
                    {
                        m = false;
                        int item = LayerMask.NameToLayer("item");
                        key.layer = item;
                        Rigid.constraints = RigidbodyConstraints.FreezeAll;
                        key.GetComponent<BoxCollider>().enabled = false;
                        sc.inhand = true;
                        
                        key.transform.SetParent(cam, true);
                        key.transform.localPosition = (vec);
                        key.transform.localEulerAngles = (vec2);
                        pick = true;    
                    }

      
                }
            }
        }
        if(pick == true)
        {
            if(ControlFreak2.CF2Input.GetKeyDown(KeyCode.F))
            {
                if (ifneed == true)
                {
                    tex.text = emty;
                }
                int def = LayerMask.NameToLayer("Default");
                key.layer = def ;
                key.GetComponent<BoxCollider>().enabled = true;
                pick = false;
                Rigid.constraints = RigidbodyConstraints.None;
                key.transform.SetParent(null);
                sc.inhand = false;
                interactable = false;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            intTex.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            audio.Play();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            intTex.SetActive(false);
            interactable = false;
        }
    }
}
