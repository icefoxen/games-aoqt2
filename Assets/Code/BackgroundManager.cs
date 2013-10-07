using UnityEngine;
using System;
using System.Collections;

public class BackgroundManager : MonoBehaviour {
	
	// For now this just makes a flat billboard
	public void SetBackground (World w)
	{
		var mf = GetComponent<MeshFilter> ();
		mf.mesh = w.GetCurrentZone().mesh;
		
		//var mr = GetComponent<MeshRenderer>();
		//mr.material.mainTexture = w.backgroundAtlas.tex;
		
		//Debug.Log ("Geometry made.");
		
	}
	
	// Use this for initialization
	void Start ()
	{
		//transform.localRotation = Quaternion.identity;
		//transform.Rotate (new Vector3 (0, 0, 1), 180);
		//transform.localScale = new Vector3 (1, 1, 1);
		
		
		/*
		var mf = GetComponent<MeshFilter> ();
		mf.mesh.uv [0] = new Vector2 (1.0f, 0.1f);
		mf.mesh.uv [1] = new Vector2 (0.0f, 0.1f);
		mf.mesh.uv [2] = new Vector2 (0.0f, 1.0f);
		Debug.Log (String.Format ("{0}, {1}, {2}", mf.mesh.uv [0], mf.mesh.uv [1], mf.mesh.uv [2]));
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
