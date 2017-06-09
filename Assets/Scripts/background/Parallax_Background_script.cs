using UnityEngine;
using System.Collections;

public class Parallax_Background_script : MonoBehaviour {

	public float HSpeed;
	public float maxLeftPosition;
	public GameObject PositionReference;
	public float distanceToReference;
	public float timesToWalk = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!Game.Data.gameover && !Game.Data.Paused) {Vector3 pos = this.gameObject.transform.position;
			pos.x -= HSpeed * (Time.deltaTime * Game.Data.globalSpeed);
			if(pos.x < maxLeftPosition) {
				pos.x += (distanceToReference * timesToWalk);
			}
			this.gameObject.transform.position = pos;
		}
	}
}
