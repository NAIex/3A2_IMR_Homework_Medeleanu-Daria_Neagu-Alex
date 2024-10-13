using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBallScoreManager : MonoBehaviour
{
    public Rigidbody ball;
    public ScoreSript scoreManager;

    //Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("fairways"))
        {
            scoreManager.OnHit();
        }
    }
}
