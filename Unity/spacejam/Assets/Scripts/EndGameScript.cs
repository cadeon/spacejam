using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public TeamsManager teamMgr;
    public Text winnerTextBox;
    // Start is called before the first frame update
    public void GameOver()
    {
        Debug.Log("Calculating Winner");
        int[] scores = { teamMgr.p1Score, teamMgr.p2Score, teamMgr.p3Score, teamMgr.p4Score };
        int highestScore = 0;
        int winningTeam = 1;
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] > highestScore)
            {
                highestScore = scores[i];
                winningTeam = i+1;
            }
        }
        
        Debug.Log("Player " + winningTeam + " wins!" );
        winnerTextBox.GetComponent<Text>().text = "PLAYER " + winningTeam + " WINS!";
    }
}
