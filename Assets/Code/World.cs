using UnityEngine;
using System.Collections;


public class World : MonoBehaviour {
	const int WIDTH = 10;
	const int HEIGHT = 10;
	
	int zoneX;
	int zoneY;
	
	public Zone[,] zones = new Zone[WIDTH,HEIGHT];

	//public GameObject TerrainCollider;

	public GameObject ZonePrefab;
	
	public void Start ()
	{

		Debug.Log ("Making world");
		for (int i = 0; i < WIDTH; i++) {
			for (int j = 0; j < HEIGHT; j++) {
				Debug.Log ("Making zone");
				var z = (GameObject) Instantiate(ZonePrefab);
				z.transform.parent = this.transform;
				z.gameObject.SetActive(false);
				zones [i, j] = z.GetComponent<Zone>();
			}
		}

		zoneX = 0;
		zoneY = 0;
		GetCurrentZone ().gameObject.SetActive(true);
	}
	
	public Zone GetCurrentZone ()
	{
		return zones [zoneX, zoneY];
	}

}
