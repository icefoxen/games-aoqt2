using UnityEngine;
using System.Collections;
using System;
using System.Text;

public class Main : MonoBehaviour {

	public GameObject prefabActor;
	public GameObject prefabSprite;
	
	Battlefield field;
	
	GameObject[] background;
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Hello World once!!");
		var friend = (GameObject)Instantiate (prefabActor);
		var foe = (GameObject)Instantiate (prefabActor);
		field = new Battlefield (friend, foe);
		
		
		/*
		int backgroundSize = 50;
		int backgroundArea = backgroundSize * backgroundSize;
		background = new GameObject[backgroundArea];
		int x = 0;
		int y = 0;
		for (int i = 0; i < backgroundArea; i++) {
			background [i] = (GameObject)Instantiate (prefabSprite);
			background [i].transform.position = new Vector3 (x, y, -2);
			Debug.Log ("Set to " + background [i].transform.position.x + " " + background [i].transform.position.y);
			x++;
			if (x >= backgroundSize) {
				x = 0;
				y++;
			}
		}
		var mf = background [0].GetComponent<MeshFilter> ();
		mf.mesh.uv [0] = new Vector2 (1.0f, 0.1f);
		mf.mesh.uv [1] = new Vector2 (0.0f, 0.1f);
		mf.mesh.uv [2] = new Vector2 (0.0f, 1.0f);
		Debug.Log (String.Format ("{0}, {1}, {2}", mf.mesh.uv [0], mf.mesh.uv [1], mf.mesh.uv [2]));
		*/
	
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
