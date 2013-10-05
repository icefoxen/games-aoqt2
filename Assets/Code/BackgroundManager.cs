using UnityEngine;
using System;
using System.Collections;

public class BackgroundMongler : MonoBehaviour {
	
	// For now this just makes a flat billboard
	void MakeGeometry ()
	{
		var mf = GetComponent<MeshFilter> ();
		var mesh = new Mesh ();
		mf.mesh = mesh;
		
		var width = 1.0f;
		var height = 1.0f;
		var verts = new Vector3[4];
		verts [0] = new Vector3 (0, 0, 0);
		verts [1] = new Vector3 (width, 0, 0);
		verts [2] = new Vector3 (0, height, 0);
		verts [3] = new Vector3 (width, height, 0);
		mesh.vertices = verts;
		
		
		var tris = new int[6] { 0, 2, 1, 2, 3, 1};
		mesh.triangles = tris;
		
		var normals = new Vector3[4];
		normals [0] = -Vector3.forward;
		normals [1] = -Vector3.forward;
		normals [2] = -Vector3.forward;
		normals [3] = -Vector3.forward;
		mesh.normals = normals;
		
		var uv = new Vector2[4];
		//uv [0] = new Vector2 (0, 0);
		//uv [1] = new Vector2 (1, 0);
		//uv [2] = new Vector2 (0, 1);
		//uv [3] = new Vector2 (1, 1);
		uv [0] = new Vector2 (0, 0);
		uv [1] = new Vector2 (1, 0);
		uv [2] = new Vector2 (0, 1);
		uv [3] = new Vector2 (1, 1);
		mesh.uv = uv;
		
		Debug.Log ("Geometry made.");
		
	}
	
	// Use this for initialization
	void Start ()
	{
		MakeGeometry ();
		//transform.Rotate (new Vector3 (1, 0, 0), 90);
		//transform.Rotate (new Vector3(0, 0, 1), 180);
		transform.localRotation = Quaternion.identity;
		transform.Rotate (new Vector3 (0, 0, 1), 180);
		transform.localScale = new Vector3 (10, 10, 10);
		
		
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
