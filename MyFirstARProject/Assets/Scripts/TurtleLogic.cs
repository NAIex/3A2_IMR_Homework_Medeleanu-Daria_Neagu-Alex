using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleLogic : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.transform.parent.gameObject.GetComponentInChildren<Animator>();
        Debug.Log(this.animator != null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LetsFight()
    {
        this.animator.SetBool("Attack", true);
    }
    private void GotAwayyy()
    {
        this.animator.SetBool("Attack", false);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Turtle"))
            LetsFight();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Turtle"))
            GotAwayyy();
        
    }
}
