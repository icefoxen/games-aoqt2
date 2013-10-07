using UnityEngine;
using System.Collections;

public class Zone {
	const int WIDTH = 16;
	const int HEIGHT = 12;
	const int NUMMOBS = 16;
	const int NUMPOWERUPS = 16;
	
	public int[,] tiles = new int[WIDTH, HEIGHT];
	public Mob[] mobs = new Mob[NUMMOBS];
	public Powerup[] powerups = new Powerup[NUMPOWERUPS];
	
	
	public const int TILEX = 4;
	
	public Mesh mesh;
	public Zone ()
	{
		//Debug.Log ("Making zone");
		SetupTiles();
		InitMesh ();
	}
	
	public void SetupTiles ()
	{
		for(int i = 0; i < WIDTH; i++) { 
			var r = (int) (Random.value * TILEX);
			tiles[i,0] = r;
		}
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
		mesh = new Mesh ();
		
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
		for (int i = 0; i < numUvs; i += 4) {
			uv [i + 0] = new Vector2 (0, 0);
			uv [i + 1] = new Vector2 (0.5f, 0);
			uv [i + 2] = new Vector2 (0, 0.5f);
			uv [i + 3] = new Vector2 (0.5f, 0.5f);
		}
		mesh.uv = uv;
	}
	
}

public class World {
	const int WIDTH = 10;
	const int HEIGHT = 10;
	
	public int zoneX;
	public int zoneY;
	
	public Zone[,] zones = new Zone[WIDTH,HEIGHT];
	
	public World ()
	{
		Debug.Log ("Making world");
		for (int i = 0; i < WIDTH; i++) {
			for (int j = 0; j < HEIGHT; j++) {
				zones [i, j] = new Zone ();
			}
		}
	}
	
	public Zone GetCurrentZone ()
	{
		return zones [zoneX, zoneY];
	}

}
