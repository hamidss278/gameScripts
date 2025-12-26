using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareRay : MonoBehaviour
{
    public float dis;
        public LayerMask lay;
        public AudioSource audio;
        public bool audios, photo, damage;
    void Update()
    {
        RaycastHit Hit;
        if(Physics.Raycast(transform.position, transform.forward, out Hit, dis, lay))
        {
            print(Hit.collider.gameObject.name);
            if(Hit.collider.gameObject.name == "mirror")
            {
               if (audios == true)
                {
                    audio.enabled = true;
                }
               /* if(photo == true)
                {

                }
                if(damage == true)
                {

                }*/
            }
        }
    }
}
