using UnityEngine;
using System.Collections;

public class move_enemy_script : MonoBehaviour {

	public float moveSpeedX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!Game.Data.bullet && !Game.Data.Paused) {
			if(this.gameObject.transform.position.x - Game.Data.Mecha.Root.transform.position.x < 24) {
				Vector3 pos = this.gameObject.transform.position;
				pos.x += moveSpeedX * Time.deltaTime;
				this.gameObject.transform.position = pos;
			}
		}
	}
}
