using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleLogic : MonoBehaviour
{
    private Animator animator;

    private Vector3 prevPos;
    private GameObject opponent;

    private float restDelay = 5.0f;
    private float nextRestTime;
    private bool resting;
    void Start()
    {
        this.animator = this.transform.parent.gameObject.GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 currentPos = gameObject.transform.position;
        float dist = Vector3.Distance(prevPos, currentPos);

        bool runDist = Vector3.Distance(prevPos, currentPos) > 0.5;
        bool walkDist = Vector3.Distance(prevPos, currentPos) > 0.1;

        if (runDist)
        {
            animator.SetBool("Run", true);
            this.WakeUp();
        }
        else if(walkDist)
        {
            animator.SetBool("Walk", true);
            this.WakeUp();
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);
        }
        prevPos = currentPos;

        if (this.opponent != null)
        {
            if (resting)
                this.WakeUp();
            nextRestTime = Time.time + restDelay;

            this.FaceOpponent();
        }
        
        if (!resting && Time.time >= nextRestTime)
        {
            this.Rest();
        }

    }
    private void Rest()
    {
        resting = true;
        this.animator.SetBool("Rest", true);
    }
    private void WakeUp()
    {
        resting = false;
        nextRestTime = Time.time + restDelay;

        this.animator.SetBool("Rest", false);
    }

    private void FaceOpponent()
    {
        this.transform.parent.LookAt(opponent.transform);
    }
    private void LetsFight(GameObject opponent)
    {
        this.animator.SetBool("Attack", true);
        this.opponent = opponent;
    }
    private void GotAwayyy()
    {
        this.animator.SetBool("Attack", false);
        this.opponent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Turtle"))
        {
            LetsFight(other.transform.parent.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Turtle"))
            GotAwayyy();
        
    }
}
