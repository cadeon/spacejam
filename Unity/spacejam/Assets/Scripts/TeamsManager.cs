using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Team { TEAM1, TEAM2, TEAM3, TEAM4 };

public class TeamsManager : MonoBehaviour
{
    public int p1Score = 0;
    public int p2Score = 0;
    public int p3Score = 0;
    public int p4Score = 0;

    public Text p1Text;
    public Text p2Text;
    public Text p4Text;
    public Text p3Text;

    public List<GameObject> team1;
	public List<GameObject> team2;
	public List<GameObject> team3;
	public List<GameObject> team4;

	public List<GameObject> team1Enemies;
	public List<GameObject> team2Enemies;
	public List<GameObject> team3Enemies;
	public List<GameObject> team4Enemies;

	void Start()
	{
		team2 = new List<GameObject>();
		team3 = new List<GameObject>();
		team1 = new List<GameObject>();
		team4 = new List<GameObject>();
		team1Enemies = new List<GameObject>();
		team2Enemies = new List<GameObject>();
		team3Enemies = new List<GameObject>();
		team4Enemies = new List<GameObject>();
	}

    private void Update()
    {
        for (var i = team1.Count - 1; i > -1; i--)
        {
            if (team1[i] == null)
                team1.RemoveAt(i);
        }
        for (var i = team2.Count - 1; i > -1; i--)
        {
            if (team2[i] == null)
                team2.RemoveAt(i);
        }
        for (var i = team3.Count - 1; i > -1; i--)
        {
            if (team3[i] == null)
                team3.RemoveAt(i);
        }
        for (var i = team4.Count - 1; i > -1; i--)
        {
            if (team4[i] == null)
                team4.RemoveAt(i);
        }
        p1Score = team1.Count;
        p2Score = team2.Count;
        p3Score = team3.Count;
        p4Score = team4.Count;

        UpdateUI();
    }

    void UpdateUI()
    {
    	p1Text.text = "Player One: " + p1Score;
    	p2Text.text = "Player Two: " + p2Score;
    	p3Text.text = "Player Three: " + p3Score;
    	p4Text.text = "Player Four: " + p4Score;
    }

    public void AddSat(Team team, GameObject sat)
	{
		switch(team) 
		{
			case Team.TEAM1:
				team1.Add(sat);
				team2Enemies.Add(sat);
				team3Enemies.Add(sat);
				team4Enemies.Add(sat);
				break;
			case Team.TEAM2:
				team2.Add(sat);
				team1Enemies.Add(sat);
				team3Enemies.Add(sat);
				team4Enemies.Add(sat);
				break;
			case Team.TEAM3:
				team3.Add(sat);
				team2Enemies.Add(sat);
				team1Enemies.Add(sat);
				team4Enemies.Add(sat);
				break;
			case Team.TEAM4:
				team4.Add(sat);
				team2Enemies.Add(sat);
				team3Enemies.Add(sat);
				team1Enemies.Add(sat);
				break;
		}

	}

	// get array of satellites that oppose this team
	public List<GameObject> EnemyTeams(Team team)
	{
		switch(team)
		{
			case Team.TEAM1:
				return team1Enemies;
			case Team.TEAM2:
				return team2Enemies;
			case Team.TEAM3:
				return team3Enemies;
			case Team.TEAM4:
				return team4Enemies;
		}
		
		return null;
	}

}
