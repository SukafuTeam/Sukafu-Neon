using UnityEngine;
using System.Collections;

public class camera_position_on_size : MonoBehaviour {

	public float last_size;

	public float shakeAmount = 0.7f;

	public Vector3 last_position;

	public float initialTime;

	// Use this for initialization
	void Start () {
		last_size = Camera.main.orthographicSize;
		last_position = this.gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if(Game.Data.begin) {
			initialTime += Time.deltaTime;
			
			if(Game.Data.shake > 0) {
				this.gameObject.transform.position = last_position;
				Vector2 pos = Camera.main.transform.position;
				Vector2 add = Random.insideUnitCircle * shakeAmount;
				pos += add;
				Camera.main.transform.position = new Vector3(pos.x, pos.y, -10);
				Game.Data.shake -= Time.deltaTime;
				pos = Camera.main.transform.position;
				pos -= add;
				last_position = new Vector3(pos.x, pos.y, -10);
			} else {
				if(initialTime > 2) {
					last_position = this.gameObject.transform.position;
					float actual_size = Camera.main.orthographicSize;
					
					if(actual_size < 9) {
						actual_size += 0.05f;
					}
					
					if(actual_size != last_size) {
						Vector3 pos = Camera.main.transform.position;
						pos.x = actual_size;
						pos.y = actual_size - 5.5f;
						Camera.main.transform.position = pos;
					}
					
					Camera.main.orthographicSize = actual_size;
					last_size = actual_size;
				}
				
			}
		}
	}
}
