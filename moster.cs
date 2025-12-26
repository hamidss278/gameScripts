using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moster : MonoBehaviour
{
    public NavMeshAgent ai;
    public GameObject fps, audiso, audidi, Monster, part, book;
    public Animator anim;
    public int RandNum, lastNumber;
    public bool idle, chase, walk, nexti, test, scared;
    public Transform player, enter1, enter2, mons, ou1, ou2;
    public List<Transform> desti;
    public AudioSource audio;
    public items cs;
    public Transform c12;
    public bool tiam;
    private Coroutine nextCoroutine;
    public float chasedis;
    public int eas, med, ha, prac;
    public SC_FPSController sccc;
    private Vector3 dost; // current destination
    private bool hasDest = false;

    public float idleDuration = 5f; // how long to stay idle after reaching a destination
    public float idleDistanceToPlayer = 5f; // distance to player to go idle while chasing

    void Start()
    {
        // If a certain mode is disabled, hide the monster
        if (PlayerPrefs.GetInt("prac") == 1)
        {
            if (Monster != null) Monster.SetActive(false);
        }

        // Choose an initial destination safely
        if (desti != null && desti.Count > 0)
        {
            RandNum = Random.Range(0, desti.Count);
            c12 = desti[RandNum];
            dost = c12.position;
            hasDest = true;
        }

        // Initialize AI
        if (ai != null)
        {
            ai.stoppingDistance = 0.5f; // adjust as needed
            ai.updateRotation = true;
            if (hasDest)
                ai.SetDestination(dost);
        }

        // State
        walk = true;
        idle = false;
        chase = false;
        scared = false;
    }

    void Update()
    {
        // If scared, stop and play scare animation
        if (scared)
        {
            part.SetActive(true);
            if (ai != null) ai.ResetPath();
            if (ai != null) ai.speed = 0f;
            walk = false;
            chase = false;
            idle = false;
            anim.SetTrigger("scared");
            anim.ResetTrigger("walk");
            anim.ResetTrigger("chase");
            anim.ResetTrigger("idle");
            // Die or end sequence
            StartCoroutine(die());
            return;
        }

        // Chasing the player
        if (chase)
        {
            idle = false;
            walk = false;
            if (player != null && ai != null)
            {
                Vector3 target = player.position;
                ai.destination = target;

                // If close enough to the player, go idle
                if (Vector3.Distance(transform.position, target) <= idleDistanceToPlayer)
                {
                    chase = false;
                    idle = true;
                    walk = false; // important: stop walking when going idle
                    if (ai != null) ai.ResetPath();
                    // Trigger idle animation immediately
                    if (anim != null)
                    {
                        anim.SetTrigger("idle");
                        anim.ResetTrigger("walk");
                        anim.ResetTrigger("chase");
                    }
                    return;
                }
            }

            // Speed based on difficulty
            if (ai != null)
            {
                if (PlayerPrefs.GetInt("easy") == 1) ai.speed = 2f;
                if (PlayerPrefs.GetInt("med") == 1) ai.speed = 2.2f;
                if (PlayerPrefs.GetInt("hard") == 1) ai.speed = 2.3f;
            }

            if (anim != null)
                anim.SetTrigger("chase");

            // If we have a reason to stop chasing (e.g., controller disabled), switch to walking
            if (sccc != null && sccc.enabled == false)
            {
                chase = false;
                walk = true;
                if (ai != null && hasDest)
                    ai.SetDestination(dost);
            }

            // Optional: if far from player for too long, end chase and resume wandering
            if (ai != null && ai.remainingDistance <= chasedis && nextCoroutine == null)
            {
                nextCoroutine = StartCoroutine(nex());
            }

            return;
        }

        // Walking between destinations
        if (walk)
        {
            if (ai != null && hasDest)
            {
                // Set speed by difficulty for walking
                if (PlayerPrefs.GetInt("easy") == 1) ai.speed = 2.2f;
                if (PlayerPrefs.GetInt("med") == 1) ai.speed = 2.4f;
                if (PlayerPrefs.GetInt("hard") == 1) ai.speed = 2.6f;
                ai.SetDestination(dost);
            }

            if (anim != null)
            {
                anim.SetTrigger("walk");
                anim.ResetTrigger("idle");
                anim.ResetTrigger("chase");
            }

            // If we reached the destination, go idle for a bit, then resume wandering
            if (ai != null && !ai.pathPending && ai.remainingDistance <= ai.stoppingDistance)
            {
                if (nextCoroutine == null)
                    nextCoroutine = StartCoroutine(IdleAndResume(idleDuration));
            }

            return;
        }

        // Idle
        if (idle)
        {
            if (ai != null) ai.speed = 0f;
            if (ai != null) ai.ResetPath();
            if (anim != null)
            {
                anim.SetTrigger("idle");
                anim.ResetTrigger("walk");
                anim.ResetTrigger("chase");
            }
            return;
        }

        // Quick helper: ensure a destination exists
        if (!hasDest && desti != null && desti.Count > 0)
        {
            RandNum = Random.Range(0, desti.Count);
            c12 = desti[RandNum];
            dost = c12.position;
            hasDest = true;
        }

        // Optional: manage a tiny "Input" state
        if (fps != null && fps.activeSelf)
        {
            nexti = false;
        }
    }

    // Coroutine: wait a bit, then choose a new random destination
    IEnumerator nextAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (!chase && desti != null && desti.Count > 0)
        {
            RandNum = Random.Range(0, desti.Count);
            c12 = desti[RandNum];
            dost = c12.position;
            if (ai != null)
            {
                ai.SetDestination(dost);
            }
            walk = true;
            idle = false;
        }
        nextCoroutine = null;
    }

    // Coroutine: a longer wait that eventually ends the chase and wanders
    IEnumerator nex()
    {
        yield return new WaitForSeconds(10.0f);
        chase = false;
        walk = true;
        idle = false;
        nexti = false;
        if (audiso != null) audiso.SetActive(true);
        if (audidi != null) audidi.SetActive(false);

        RandNum = Random.Range(0, desti.Count);
        c12 = desti[RandNum];
        dost = c12.position;
        if (ai != null) ai.SetDestination(dost);
        nextCoroutine = null;
    }

    // Idle then resume to a new destination
    IEnumerator IdleAndResume(float seconds)
    {
        // Enter idle state
        idle = true;
        walk = false;
        if (ai != null) ai.ResetPath();
        if (anim != null)
        {
            anim.SetTrigger("idle");
            anim.ResetTrigger("walk");
            anim.ResetTrigger("chase");
        }

        yield return new WaitForSeconds(seconds);

        // Choose next destination and resume walking
        if (desti != null && desti.Count > 0)
        {
            RandNum = Random.Range(0, desti.Count);
            c12 = desti[RandNum];
            dost = c12.position;
            hasDest = true;
            if (ai != null) ai.SetDestination(dost);
        }

        idle = false;
        walk = true;
        if (anim != null)
        {
            anim.SetTrigger("walk");
            anim.ResetTrigger("idle");
            anim.ResetTrigger("chase");
        }

        nextCoroutine = null;
    }

    // Item pick-up coroutine (kept from your version; adapt as needed)
    IEnumerator item()
    {
        yield return new WaitForSeconds(0.1f);
        dost = player.position;
        if (ai != null) ai.SetDestination(dost);
        walk = true;
    }

    // Die/disable sequence
    IEnumerator die()
    {
        yield return new WaitForSeconds(2.0f);
        if (Monster != null) Monster.SetActive(false);
        if (book != null) book.SetActive(false);
        // Stop all coroutines to be safe
        StopAllCoroutines();
    }
}