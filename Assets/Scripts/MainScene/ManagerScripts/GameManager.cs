using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Score
    {
        Player1Score,
        player2Score
    }

    public TMPro.TextMeshProUGUI Player1ScoreTXT, Player2ScoreTXT;

    public UIManager uiManager;

    public int MaxScore = 7;

    #region Scores
    private int player1Score, player2Score;

    private int Player2Score
    {
        get { return player2Score; }
        set 
        {
            player2Score = value; 
            if(value == MaxScore)
            {
                uiManager.ShowRestartCanvas(true);
            }
        }
    }

    private int Player1Score
    {
        get { return player1Score; }
        set
        {
            player1Score = value;
            if (value == MaxScore)
            {
                uiManager.ShowRestartCanvas(false);
            }
        }
    }

    #endregion

    public void Increment(Score whichScore)
    {
        switch (whichScore)
        {
            case Score.Player1Score:
                Player1Score++;
                Player1ScoreTXT.text = player1Score.ToString();
                break;
            case Score.player2Score:
                Player2Score++;
                Player2ScoreTXT.text = player2Score.ToString();
                break;
            default:
                break;
        }
    }

    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        Player1ScoreTXT.text = player1Score.ToString();
        Player2ScoreTXT.text = player2Score.ToString();
    }
}
