using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject prefabActor;
	
	Battlefield field;
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Hello World once!!");
		var friend = (GameObject)Instantiate (prefabActor);
		var foe = (GameObject)Instantiate (prefabActor);
		field = new Battlefield (friend, foe);
		
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//testsprite.transform.Translate (0.05f, 0f, 0f);
		
	}
	
	void Update()
	{
		//testsprite2.transform.Translate (0.05f, 0f, 0f);
	}
}
