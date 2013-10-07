using UnityEngine;
using System.Collections;
using System;
using System.Text;

public class Main : MonoBehaviour {

	public BackgroundManager background;
	//public GameObject prefabActor;
	
	public Texture backgroundAtlas;
	public Texture playerAtlas;
	public Texture mobAtlas;
	public Texture weaponAtlas;
	public Texture powerupAtlas;
	
	World w;
	
	// Use this for initialization
	void Start ()
	{
		// Apparently Unity doesn't like new gameobjects like meshes being
		// created during a constructor...?
		// So we have to init the world here, because it makes a bunch of
		// zones which all contain background meshes and such...
		w = new World (backgroundAtlas);
		background.SetBackground (w);
	
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
