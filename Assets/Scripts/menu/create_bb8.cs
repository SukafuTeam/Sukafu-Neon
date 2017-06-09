using UnityEngine;
using System.Collections;

public class create_bb8 : MonoBehaviour {

	public GameObject bb8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateBB8() {
		float randX = Random.Range(-7.2f,7.2f);
		float randY = Random.Range(-4.2f, 4.2f);
		Game.Spawn(bb8, new Vector3(randX, randY, 0), Quaternion.identity);
	}
}
