using UnityEngine;
using System.Collections;

public class ActorController : MonoBehaviour {
	
	int hp = 10;
	public int attackpower = 2;
	public double accuracy = 0.9;

	// Use this for initialization
	void Start () {
		Debug.Log ("Actor created.");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		this.transform.Translate (0.05f, 0f, 0f);
	}
	
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
}
