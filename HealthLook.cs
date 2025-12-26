using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLook : MonoBehaviour
{
    public PlayerHealth sc;
    public nights cs;
    public LayerMask layer;
    public float dis;
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, dis, layer))
        {
            print(hit.collider.gameObject.name);
            if(hit.collider.gameObject.name == "W2")
            {
                sc.health -= 70 * Time.deltaTime;
            }
        }
    }
}
