using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{ 
    public GameObject ball; 
    //public ScoreScript scoreManager;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You reached the end!");
        ScoreManager.instance.WinGame();
    }
}
