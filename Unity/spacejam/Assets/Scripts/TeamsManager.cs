using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team { TEAM1, TEAM2, TEAM3, TEAM4 };		

public class TeamsManager : MonoBehaviour
{

	public List<GameObject> team1;
	public List<GameObject> team2;
	public List<GameObject> team3;
	public List<GameObject> team4;

	public List<GameObject> team1Enemies;
	public List<GameObject> team2Enemies;
	public List<GameObject> team3Enemies;
	public List<GameObject> team4Enemies;

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
