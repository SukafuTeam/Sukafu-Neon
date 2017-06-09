using UnityEngine;
using System.Collections;

public class MoveWithCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(!Game.Data.Paused && !Game.Data.bullet && !Game.Data.gameover) {
			Vector3 pos = this.transform.position;
			pos.x -= Game.Data.HSpeed * Game.Data.globalSpeed * Time.deltaTime;
			this.transform.position = pos;

		}

		if(this.gameObject.transform.position.x < -100) {
			Destroy(this.gameObject);
		}

	}
}
