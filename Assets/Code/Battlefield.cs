using UnityEngine;
using System.Collections;

public class Battlefield {
	
	GameObject background;
	GameObject[] playerParty;
	GameObject[] enemies;
	
	public Battlefield (GameObject friends, GameObject foes)
	{
		playerParty = new GameObject[1];
		enemies = new GameObject[1];
		playerParty [0] = friends;
		enemies[0] = foes;
	}
}
