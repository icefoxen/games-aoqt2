using UnityEngine;
using System.Collections;
using System;
using System.Text;


public class Main : MonoBehaviour {

	public GameObject prefabActor;
	public World w;
	GameObject player;
	
	// Use this for initialization
	void Start ()
	{
		// Apparently Unity doesn't like new gameobjects like meshes being
		// created during a constructor...?
		// So we have to init the world here, because it makes a bunch of
		// zones which all contain background meshes and such...
		//background.SetBackground (w);
		player = (GameObject)Instantiate (prefabActor);
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
