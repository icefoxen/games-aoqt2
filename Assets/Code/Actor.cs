using UnityEngine;
using System.Collections;

enum facing {
	UP,
	DOWN,
	LEFT,
	RIGHT,
	MAX
}

public class Actor : MonoBehaviour {
	
	
	public Vector2 vel;
	public Vector2 boundingBox;
	
	int flashyTime;
	int flashTimer;
	bool show;
	
	int hits;
	
	// XXX: Animation?

	// Use this for initialization
	void Start () {
		transform.Translate(0, 0, -1);
		Debug.Log ("Actor created.");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		this.transform.Translate (0.05f, 0f, 0f);
		//Debug.Log (this.transform.position.x);
	}
	
	/*
	void takeDamage (int damage)
	{
		hp -= damage;
	}
	
	int? attack (ActorController target)
	{
		var tohit = Random.value;
		
		if (tohit < accuracy) {
			target.takeDamage (attackpower);
			return attackpower;
		} else {
			return null;
		}
	}
	*/
}




public class Player : Actor {
	const int PLAYERSPEED = 300;
	const int ARROWSPEED = 300;
	const int MAXHITS = 10;
	const int STARTINGARROWS = 10;
	const int SWORDDAMAGE = 3;
	const int ARROWDAMAGE = 2;
	const int FLASHYTIME = 750;
	const int ARROWREFIRE = 300;
	const int SWORDREFIRE = 750;
	const int SWORDDURATION = (SWORDREFIRE * 2) / 3;
}
