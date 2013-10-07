using UnityEngine;
using System.Collections;

public class Atlas {

	public Texture tex;
	// number of tiles in the sprite atlas
	public int width;
	public int height;
	
	public Atlas(Texture t, int w, int h) {
		tex = t;
		width = w;
		height = h;
	}
	
	public Vector2 GetSpriteSize() {
		var w = 1.0f / width;
		var h = 1.0f / height;
		return new Vector2(w, h);
	}
	
	public Vector4 GetSpriteCoords(int index) {
		if(index < 0 || index >= width*height) {
			Debug.LogError("Invalid sprite coordinates!");
		}
		
		var size = GetSpriteSize();
		var xoffset = (index % width) * size.x;
		var yoffset = (index / width) * size.y;
		
		return new Vector4(xoffset, yoffset, size.x, size.y);
	}
}
