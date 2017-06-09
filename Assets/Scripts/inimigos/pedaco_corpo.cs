using UnityEngine;
using System.Collections;

public class pedaco_corpo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody2D rig = this.gameObject.GetComponent<Rigidbody2D>();
		rig.angularVelocity = Random.Range(400,1000);
		rig.velocity = new Vector2(Random.Range(5,-5), Random.Range(30, -10));
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.transform.position.y < -10) {
			Destroy(this.gameObject);
		}
	}
}
