using UnityEngine;
using System.Collections;

public class Atlas {
	// number of tiles in the sprite atlas
	public const int width = 16;
	public const int height = 16;
	
	public static Vector2 GetSpriteSize() {
		var w = 1.0f / width;
		var h = 1.0f / height;
		return new Vector2(w, h);
	}
	
	public static Vector4 GetSpriteCoords(int index) {
		if(index < 0 || index >= width*height) {
			Debug.LogError("Invalid sprite coordinates!");
		}
		
		var size = GetSpriteSize();
		var xoffset = (index % width) * size.x;
		var yoffset = (index / width) * size.y;
		
		return new Vector4(xoffset, yoffset, size.x, size.y);
	}
}
