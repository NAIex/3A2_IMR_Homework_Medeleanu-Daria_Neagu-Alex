using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ClubSpawner : MonoBehaviour
{
    public InputActionProperty createButton;
    public GameObject clubPrefab;

    private GameObject clubRef;
    private void Awake()
    {
        clubRef = Instantiate(clubPrefab,gameObject.transform.position, gameObject.transform.rotation);
        clubRef.SetActive(false);
    }
    private void TeleportClub()
    {
        clubRef.SetActive(false);

        Rigidbody comp = clubRef.GetComponent<Rigidbody>();
        comp.velocity = Vector3.zero;
        //comp.angularVelocity= Vector3.zero;

        clubRef.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);

        clubRef.SetActive(true);
    }
    private void Update()
    {
        if(createButton.action.WasPressedThisFrame())
        {
            if (ScoreManager.instance.IsGameWon())
                ScoreManager.instance.TryAgain();
            TeleportClub();
        }
    }
}
