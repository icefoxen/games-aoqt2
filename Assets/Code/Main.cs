using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject prefabSprite;
	
	GameObject testsprite;
	GameObject testsprite2;
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Hello World once!!");
		testsprite = (GameObject) Instantiate (prefabSprite);
		testsprite2 = (GameObject)Instantiate (prefabSprite);
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		testsprite.transform.Translate (0.05f, 0f, 0f);
		
	}
	
	void Update()
	{
		testsprite2.transform.Translate (0.05f, 0f, 0f);
	}
}
