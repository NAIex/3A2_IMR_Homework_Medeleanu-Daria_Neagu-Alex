using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubLogic : MonoBehaviour
{
    private float hitCooldown = 0.5f;
    private float nextCountedHit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if(Time.time >= nextCountedHit)
            {
                ScoreManager.instance.IncreaseScore();
                nextCountedHit = Time.time + hitCooldown;
            }
        }   
    }
}
