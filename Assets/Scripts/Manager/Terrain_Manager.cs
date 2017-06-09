using UnityEngine;
using System.Collections;

public class Terrain_Manager : MonoBehaviour {

	public GameObject terrain;

	public GameObject[] terrain_game;
	public int[] index = new int[] {0,1,0,2,1,3,2,4,3,5,4,6,5,7,6,8,7,9,8,10,9,11,10,12,11,13,12,14,13,14};


	public GameObject actual_terrain;
	public int created;
	public int actualIndex;

	// Use this for initialization
	void Start () {
		created = 1;
		actualIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(actual_terrain.transform.position.x < 10) {
			Vector3 pos = actual_terrain.transform.position;
			GameObject clone;

			if(!Game.Data.begin) {
				clone = Game.Spawn(terrain, new Vector3(pos.x + 50, pos.y, pos.z), Quaternion.identity);
				actual_terrain = clone;
			} else {
				if(created < 1) {
					clone = Game.Spawn(terrain, new Vector3(pos.x + 50, pos.y, pos.z), Quaternion.identity);
				} else {
					if(actualIndex < 28) {
						clone = Game.Spawn(terrain_game[index[actualIndex]], new Vector3(pos.x + 50, pos.y, pos.z), Quaternion.identity);
						actualIndex++;
					} else {
						clone = Game.Spawn(terrain, new Vector3(pos.x + 50, pos.y, pos.z), Quaternion.identity);
						Application.LoadLevel("cena_creditos");
					}
				}
				actual_terrain = clone;
				created++;
			}
		}
	}
}
