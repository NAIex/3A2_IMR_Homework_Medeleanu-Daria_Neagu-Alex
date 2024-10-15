using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    public TextMeshProUGUI scoreDisplay;

    public TextMeshProUGUI winScoreDisplay;
    public Animator winScreen;
    private bool wonGame = false;

    private int currentScore = 0;

    void Awake()
    {
        Init();
        UpdateText();
        
    }
    public void IncreaseScore()
    {
        if (wonGame)
            return;
        this.currentScore++;
        UpdateText();
    }
    public void WinGame()
    {
        wonGame = true;
        UpdateWinText();
        winScreen.Play("WinAnim");
    }
    public bool IsGameWon()
    {
        return wonGame;
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void UpdateWinText()
    {
        winScoreDisplay.text = "Final score was: ";
        winScoreDisplay.text += CalcScoreString();
    }
    private string CalcScoreString()
    {
        string score = null;
        if (currentScore < 100)
            score += '0';
        if (currentScore < 10)
            score += '0';
        score += currentScore;
        return score;
    }
    private void UpdateText()
    {
        scoreDisplay.text = "Score: ";
        scoreDisplay.text += CalcScoreString();
    }
    private void Init()
    {
        if (ScoreManager.instance == null)
            ScoreManager.instance = this;
    }
}
