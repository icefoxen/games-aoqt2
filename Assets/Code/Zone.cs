using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



public struct Rect {
	public float x;
	public float y;
	public float w;
	public float h;
}

public class Zone : MonoBehaviour {

	const int WIDTH = 16;
	const int HEIGHT = 16;
	const int NUMMOBS = 16;
	const int NUMPOWERUPS = 16;
		
	// XXX: I am conflicted a little with regards to terrain size and how to do
	// the collision map for a level.
	// FOR NOW, we will remain true to the original AOQT:
	// Sprite maps are 16x16 sprites, for 256 per map.
	// For the terrain map, the lower 128 sprites do not collide, the upper 128 do.
	public int[,] tiles = new int[WIDTH, HEIGHT];
	public Mob[] mobs = new Mob[NUMMOBS];
	public Powerup[] powerups = new Powerup[NUMPOWERUPS];

	public GameObject TerrainColliderPrefab;
	public List<GameObject> colliders = new List<GameObject> ();
		
	//public const int TILEX = 4;

	public Rect? IntersectingTile(GameObject g) 
	{
		return null;
	}
		
	//public void CheckTerrainCollision(

	public bool tileIsPassable(int x, int y)
	{
		return tiles [x, y] < 128;
	}

	public void GenerateEmptyMap()
	{
		var t = 0;
		for(int i = 0; i < WIDTH; i++) {
			for(int j = 0; j < HEIGHT; j++) {
				if(i == 0 || i == (WIDTH-1) || j == 0 || j == (HEIGHT-1)) {
					tiles[i,j] = 128;
				} else {
					tiles[i, j] = 0;
				}
				//tiles[i,j] = t;
				//t = (t + 1) % 256;
			}
		}
	}

		
	public void SetupTiles ()
	{
		/*
		for(int i = 0; i < WIDTH; i++) {
			for(int j = 0; j < HEIGHT; j++) {
				var r = (int) (Random.value * Atlas.width * Atlas.height);
				tiles[i, j] = r;
			}
		}
		*/
		GenerateEmptyMap ();
	}

	public void SetupColliders() 
	{
		// For now we just create a collider for each tile that is false for tileIsPassable()
		// Later we will consider the map and merge small colliders into bigger ones, which
		// can be done in a non-optimal-but-easy way just by checking and merging along one axis.
		for (int i = 0; i < WIDTH; i++) {
			for(int j = 0; j < HEIGHT; j++) {
				if(!tileIsPassable(i,j)) {
					var c = (GameObject) Instantiate (TerrainColliderPrefab);
					colliders.Add(c);
					// the 0.5 is to nudge things a little so they're centered compared to the background
					var cx = i + this.transform.position.x + 0.5f;
					var cy = j + this.transform.position.y + 0.5f;
					c.transform.Translate (new Vector3(cx, cy, 0));
					c.transform.parent = this.transform;
				}
			}
		}
		//Debug.Log (String.Format("{0}, {1}, {2}", WIDTH, HEIGHT, colliders.Count));
	}

		
	/*
	public Vector2 TileToOffset(int i) {
	const int TILESPERROW = 2;
	const int TILESPERCOLUMN = 2;

	const float spriteW = 1.0f / TILESPERROW;
	const float spriteH = 1.0f / TILESPERCOLUMN;

	var tileXOffset = i % TILESPERROW;
	var tileYOffset = i / TILESPERROW;
	return new Vector2(tileXOffset, tileYOffset);
		
	var tileX = 0;
	var tileY = 0;

	}
	*/
		
		
	public void InitMesh ()
	{
		// ...why am I doing this the hard way, anyway?
		// Because it's the RIGHT WAY
		var mesh = new Mesh ();

		const int numSquares = WIDTH * HEIGHT;
		var numVerts = numSquares * 4;
		var numTris = numSquares * 6;
		var numNormals = numSquares * 4;
		var numUvs = numSquares * 4;

		var verts = new Vector3[numVerts];
		var vert = 0;
		for (int i = 0; i < WIDTH; i++) {
			for (int j = 0; j < HEIGHT; j++) {
				//var vert = j * WIDTH + i;
				// All tiles have a size of 1
				verts [vert + 0] = new Vector3 (i, j, 0);
				verts [vert + 1] = new Vector3 ((i + 1), j, 0);
				verts [vert + 2] = new Vector3 (i, (j + 1), 0);
				verts [vert + 3] = new Vector3 ((i + 1), (j + 1), 0);
				vert += 4;
			}
		}


		mesh.vertices = verts;

		var tris = new int[numTris];
		for (int i = 0; i < numSquares; i++) {
			var vertOffset = i * 4;
			var tri = i * 6;
			tris [tri + 0] = vertOffset + 0;
			tris [tri + 1] = vertOffset + 2;
			tris [tri + 2] = vertOffset + 1;
			tris [tri + 3] = vertOffset + 2;
			tris [tri + 4] = vertOffset + 3;
			tris [tri + 5] = vertOffset + 1;
		}


		mesh.triangles = tris;

		var normals = new Vector3[numNormals];
		for (int i = 0; i < numNormals; i += 4) {
			normals [i + 0] = -Vector3.forward;
			normals [i + 1] = -Vector3.forward;
			normals [i + 2] = -Vector3.forward;
			normals [i + 3] = -Vector3.forward;
		}


		mesh.normals = normals;

		var uv = new Vector2[numUvs];
		var quad = 0;
		for(int i = 0; i < WIDTH; i++) {
			for(int j = 0; j < HEIGHT; j++) {
				var rect = Atlas.GetSpriteCoords(tiles[i, j]);
				var width = rect.z;
				var height = rect.w;
				uv[quad + 0] = new Vector2(rect.x, rect.y);
				uv[quad + 1] = new Vector2(rect.x + width, rect.y);
				uv[quad + 2] = new Vector2(rect.x, rect.y + height);
				uv[quad + 3] = new Vector2(rect.x + width, rect.y + height);
				/*
				uv[quad + 0] = new Vector2(rect.x, rect.y);
				uv[quad + 1] = new Vector2(rect.x + width, rect.y);
				uv[quad + 2] = new Vector2(rect.x, rect.y + height);
				uv[quad + 3] = new Vector2(rect.x + width, rect.y + height);
				*/
				//Debug.Log (String.Format("coords: {0}, {0}, {0}, {0}", rect.x, rect.y, rect.z, rect.w));
				//Debug.Log (String.Format("coordseses: {0}, {0}, {0}, {0}", 
				//                         uv[quad + 0].ToString ("F4"), uv[quad + 1].ToString ("F4"), 
				//                         uv[quad + 2].ToString ("F4"), uv[quad + 3].ToString ("F4")));
				quad += 4;
			}
		}


		/*
	for (int i = 0; i < numUvs; i += 4) {
		uv [i + 0] = new Vector2 (0, 0);
		uv [i + 1] = new Vector2 (0.5f, 0);
		uv [i + 2] = new Vector2 (0, 0.5f);
		uv [i + 3] = new Vector2 (0.5f, 0.5f);

	}
	*/
		mesh.uv = uv;

		var mf = GetComponent<MeshFilter> ();
		mf.mesh = mesh;
	}
	// Use this for initialization
	void Start () {
		//Debug.Log ("Making zone");
		SetupTiles();
		SetupColliders ();
		InitMesh ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
