using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSript : MonoBehaviour
{
    private int score = 1000;
    public Text scoreText;
    public Rigidbody ball;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
    public void OnHit()
    {
        SubtractScore(100);
    }
    public void SubtractScore(int value)
    {
        score -= value;
        if(score < 0)
        {
            score = 0;
        }
        UpdateScore();
    }
}
