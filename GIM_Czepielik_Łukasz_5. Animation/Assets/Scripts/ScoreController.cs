using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public const int TRIGGER_AMOUNT_OF_POINTS = 1;
    public const int GAME_FINISHED_AMOUNT_OF_POINTS = 10;

    private int _score;

    public Text scoreText;
    public Text gameFinishedText;


    // Start is called before the first frame update
    void Start()
    {
        _score = 0;

        UpdateScoreText();
        InitializeGameFinishedText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore()
    {
        _score = _score + TRIGGER_AMOUNT_OF_POINTS;
        UpdateScoreText();
        CheckIfPlayerWon();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + _score.ToString();
    }

    void CheckIfPlayerWon()
    {
        if (_score >= GAME_FINISHED_AMOUNT_OF_POINTS)
        {
            gameFinishedText.text = "You have finished the game!";
        }
    }

    void InitializeGameFinishedText()
    {
        gameFinishedText.text = "";
    }
}
