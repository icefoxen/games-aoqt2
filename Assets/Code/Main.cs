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

		Vector2 pos = Vector2.zero;
		for (int i = 0; i < 1000; i++) {
			Vector2 dest = Sirpenski();
			float x = (pos.x + dest.x) / 2;
			float y = (pos.y + dest.y) / 2;
			pos.x = x;
			pos.y = y;
			var g = (GameObject) Instantiate (prefabActor);
			g.transform.Translate(x, y, 0);


		}
	}

	const int x1 = -15;
	const int y1 = -15;
	const int x2 = 15;
	const int y2 = -15;
	const int x3 = 0;
	const int y3 = 15;
	Vector2 Sirpenski() {
		var r = Math.Floor (UnityEngine.Random.value * 3);
		if (r == 0) {
			return new Vector2(x1, y1);
		} else if (r == 1) {
			return new Vector2(x2, y2);
		} else {
			return new Vector2(x3, y3);
		}
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
