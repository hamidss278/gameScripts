using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterRaycast : MonoBehaviour
{
    public float dis;
    public LayerMask layer;
    public moster sc;
    public Vector3 rara;
    public Transform player, book;
    public GameObject light;

    // Time after last sighting to give up chase
    public float timeToLoseSight = 2f;
    private float timeSinceLastSeen = 0f;

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit Hit;

        bool sawPlayerThisFrame = false;

        if (Physics.Raycast(transform.position + rara, direction, out Hit, dis, layer))
        {
            Debug.DrawLine(transform.position, Hit.point, Color.red);
            Debug.DrawRay(transform.position, transform.forward);

            // Check if the hit object is the player (or its controller is enabled)
            var controller = Hit.collider.GetComponent<SC_FPSController>();
            if (controller != null && controller.enabled)
            {
                sawPlayerThisFrame = true;
            }

            // Optional: if you prefer a direct check against the player object
            // if (Hit.collider.gameObject == player.gameObject) sawPlayerThisFrame = true;
        }

        if (sawPlayerThisFrame)
        {
            timeSinceLastSeen = 0f;
            sc.chase = true;
            sc.walk = false;

            if (book != null && book.transform.parent != null && book.transform.parent.gameObject.name == "item")
            {
                sc.scared = true;
            }
        }
        else
        {
            timeSinceLastSeen += Time.deltaTime;
            if (timeSinceLastSeen >= timeToLoseSight)
            {
                // Stop chasing after not seeing the player for a while
                sc.chase = false;
            }
        }
    }
}