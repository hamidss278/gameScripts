using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialStarter : MonoBehaviour
{
    public string dial, ans1, ans2, ans, ansar;
    public allDial sc;
    public bool interactable, scene, ifAnim, events, ifObj;
    public Animator anim;
    public GameObject cutscene, IntTex, box, obj;

    void Update()
    {
        if(interactable == true)
        {
            if(ControlFreak2.CF2Input.GetMouseButtonDown(0))
            {
                if (scene == true)
                {
                    box.GetComponent<BoxCollider>().enabled = true;
                }
                if (ifObj == true)
                {
                    obj.SetActive(true);
                }
                sc.answer = ans;
                sc.dial = dial;
                sc.answer1 = ans1;
                sc.answer2 = ans2;
                sc.anser = ansar;
                sc.isTalking = true;
                sc.Dial.SetActive(true);
                IntTex.SetActive(false);
                anim.SetTrigger("talk");
                interactable = false;
                this.enabled = false;
                
            }
        }
        if (sc.ended == true)
        {
            if (events == true)
            {
                box.SetActive(true);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            interactable = true;
            IntTex.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactable = false;
            IntTex.SetActive(false);
        }
    }
}
