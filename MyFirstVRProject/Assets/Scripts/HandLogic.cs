using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandLogic : MonoBehaviour
{
    public InputActionProperty grabButton;
    private Animator handAnimator;

    private void Awake()
    {
        handAnimator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if(grabButton.action.WasPressedThisFrame())
            handAnimator.SetBool("Grabbing",true);
        if (grabButton.action.WasReleasedThisFrame())
            handAnimator.SetBool("Grabbing", false);
    }
}
